using Assets;


public class SQLiteHelper_Example
{
    /// <summary>
    /// SQLite数据库辅助类
    /// </summary>
    private static SQLiteHelper sql;
    //SQLiteTools sqLiteTools;

    // Use this for initialization
    public static void Start()
    {
       

        //string path = "Data Source=D://temp//1212.db";
        //SQLiteTools.Instance.Open(path);


        //各平台下数据库存储的绝对路径(通用)
        //PC：("data source=" + Application.dataPath + "/幻世界.db");
        //Mac：("data source=" + Application.dataPath + "/幻世界.db");
        //Android：("URI=file:" + Application.persistentDataPath + "/幻世界.db");
        //iOS：("data source=" + Application.persistentDataPath + "/幻世界.db");


        sql = new SQLiteHelper("data source=10000.db");

        //1.创建名为table1的数据表  CREATE TABLE IF NOT EXISTS t_user(uid integer primary key,uname varchar(20),mobile varchar(20))
        sql.CreateTable("UserInfo1", new string[] { "UniqueID", "Name", "Age", "PhoneNum" }, new string[] { "int", "string", "int", "string" });

        //插入两条数据
        sql.InsertValues("UserInfo1", new string[] { "'1'", "'张乐'", "'22'", "'18563215897'" });
        sql.InsertValues("UserInfo1", new string[] { "'2'", "'李奇端'", "'25'", "'1683245892'" });

        //更新数据，将Name="张乐"的记录中的Name改为"zhangle"
        sql.UpdateValues("UserInfo1", new string[] { "Name" }, new string[] { "'zhangle'" }, "Name", "=", "'张乐'");

        //插入3条数据
        sql.InsertValues("UserInfo1", new string[] { "3", "'王天科'", "25", "'18565789511'" });
        sql.InsertValues("UserInfo1", new string[] { "4", "'赵视差'", "26", "'17745898567'" });
        sql.InsertValues("UserInfo1", new string[] { "5", "'刘采集'", "27", "'13965235489'" });
        

        ////创建数据库名称为xuanyusong.db
        //DbAccess db = new DbAccess("data source=xuanyusong.db");

        ////创建数据库表，与字段
        //db.CreateTable("momo", new string[] { "name", "qq", "email", "blog" }, new string[] { "text", "text", "text", "text" });
        ////关闭对象
        //db.CloseSqlConnection();
    }
    
}
