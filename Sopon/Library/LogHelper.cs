using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Sopon.Library
{
    public class LogHelper
    {
        private SQLiteConnection sqlConn;

        public LogHelper(SQLiteConnection conn)
        {
            sqlConn = conn;
        }

        public int DoErrorLogging(LogType type, OperationType opType, Exception ex)
        {
            try
            {
                string sql = @"INSERT INTO Logs (
                                        LogType,
                                        LogMessage,
                                        StackTrace,
                                        LoggedDatetime,
                                        OperationType
                                    )
                          VALUES ('"
                            + type.ToString() + "\',\'"
                            + ex.Message.ToString() + "\',\'"
                            + ex.StackTrace + "\',\'"
                            + DateTime.Now.ToString() + "\',\'"
                            + opType.ToString() + "\')";

                SQLiteCommand command = new SQLiteCommand(sql, sqlConn);
                return command.ExecuteNonQuery();
            }
            catch (Exception excp)
            {
                return -1;
            }
        }
    }

    public enum LogType
    {
        Information = 0,
        Error = 1,
    }

    public enum OperationType
    {
        Query = 0,
        Update,
        Delete,
        Create,
    }
}