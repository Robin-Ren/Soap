using Sopon.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sopon.DBAccess
{
    public class DatabaseAccess
    {
        private SQLiteConnection m_dbConnection;

        public DatabaseAccess()
        {
            try
            {
                string dbFilePath = new Uri(string.Format("{0}\\DBFile\\SoponDB.db3", Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase))).AbsolutePath.Replace("%20", " ");
                //bool isExist = File.Exists(path);

                SQLiteConnectionStringBuilder conn_builder = new SQLiteConnectionStringBuilder
                {

                    DateTimeFormat = SQLiteDateFormats.ISO8601,
                    SyncMode = SynchronizationModes.Off,
                    Version = 3,
                    //JournalMode = SQLiteJournalModeEnum.Memory,
                    //DefaultIsolationLevel = System.Data.IsolationLevel.ReadCommitted,
                    Pooling = true,
                    DataSource = dbFilePath//new Uri(string.Format("{0}\\DBFiles\\MIS_v3.sqlite", Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase))).AbsolutePath

                };

                ////连接字符串
                m_dbConnection = new SQLiteConnection(conn_builder.ConnectionString);
                m_dbConnection.Open();
            }
            catch (Exception ex)
            {
                //LogHelper logger = new LogHelper(m_dbConnection);
                //logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
            }
        }

        public List<OutCome> GetAllOutcomeDetails()
        {
            List<OutCome> retOutcomeDetails = new List<OutCome>();

            try
            {
                string sql = @"SELECT SID,
                            OutcomeName ,
                            OutcomeAmount,
                            OutcomeDescription,
                            GoodsUnitPrice,
                            GoodsCount,
                            DateCreated
                            FROM Outcome";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        OutCome item = new OutCome();
                        item.OutcomeName = row[1].ToString();
                        item.Amout = Convert.ToDouble(row[2]);
                        item.OutcomeDesc = row[3].ToString();
                        item.GoodsUnitPrice = Convert.ToDouble(row[4].ToString());
                        item.GoodsCount = Convert.ToInt32(row[5].ToString());
                        item.CreatedDate = Convert.ToDateTime(row[6]);

                        retOutcomeDetails.Add(item);
                    }
                }


            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
            }

            return retOutcomeDetails;
        }

        public int AddNewOutcomeRecord(OutCome newRec)
        {
            if (newRec == null)
                return -1;

            try
            {
                string sql = @"INSERT INTO Outcome (
                            OutcomeName ,
                            OutcomeAmount,
                            OutcomeDescription,
                            GoodsUnitPrice,
                            GoodsCount,
                            DateCreated
                            ) VALUES ('"
                            + newRec.OutcomeName.ToString() + "\',\'"
                            + newRec.Amout + "\',\'"
                            + newRec.OutcomeDesc + "\',\'"
                            + newRec.GoodsUnitPrice + "\',\'"
                            + newRec.GoodsCount + "\',\'"
                            + newRec.CreatedDate.ToString("yyyy-MM-dd") + "\')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper logger = new LogHelper(m_dbConnection);
                logger.DoErrorLogging(LogType.Error, OperationType.Query, ex);
                return -1;
            }
        }
    }
}