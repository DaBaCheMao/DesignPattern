/*
 * 适配器模式 - .Net既有的例子:数据库数据适配器，将数据库的操作简化
 */
using System;

using MySql.Data.MySqlClient;//新引入的命名空间
using System.Configuration;//新引入的命名空间
using System.Data;
using System.Data.SqlClient;

public class SqlConnect
{

    public void select(object sender, EventArgs e)
    {

        //获得Web.config中的配置信息 这里得到的是数据库连接字符串
        string sqlCconnStr = ConfigurationManager.ConnectionStrings["MySqlStr"].ConnectionString;

        //连接数据库 
        MySqlConnection sqlCon = new MySqlConnection(sqlCconnStr);

        //建立DataSet对象(相当于建立前台的虚拟数据库)
        DataSet ds = new DataSet();

        //建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
        DataTable dtable;

        //建立DataRowCollection对象(相当于表的行的集合)
        DataRowCollection coldrow;

        //建立DataRow对象(相当于表的列的集合)
        DataRow drow;



        //打开连接
        sqlCon.Open();

        //建立DataAdapter对象  
        string sltStr = "select id,username,password from user ";//重点，重点，重点，编写符合你查询条件的sql语句
        MySqlCommand sqlCmd = new MySqlCommand(sltStr, sqlCon);
        //数据库数据适配器 一定要指定DataAdapter的InsertCommand
        MySqlDataAdapter msda = new MySqlDataAdapter(sqlCmd);
        //或者以下初始化1
        //MySqlDataAdapter msda = new MySqlDataAdapter();
        //msda.SelectCommand = sqlCmd;
        //或者以下初始化2
        //MySqlDataAdapter msda = new MySqlDataAdapter(sltStr, sqlCon);
        //或者以下初始化3
        //MySqlDataAdapter msda = new MySqlDataAdapter(sltStr, sqlCconnStr);


        //将查询的结果存到虚拟数据库ds中的虚拟表tabuser中
        msda.Fill(ds, "tabuser");

        //将数据表tabuser的数据复制到DataTable对象（取数据）
        dtable = ds.Tables["tabuser"];

        //用DataRowCollection对象获取这个数据表的所有数据行
        coldrow = dtable.Rows;

        //逐行遍历，取出各行的数据
        for (int inti = 0; inti < coldrow.Count; inti++)
        {
            drow = coldrow[inti];
            Console.WriteLine($"{drow[0]} | {drow[1]} | {drow[2]}");
        }




        sqlCon.Close();
        sqlCon = null;


    }

    public void update(object sender, EventArgs e)
    {


        //获得Web.config中的配置信息
        string sqlCconnStr = ConfigurationManager.ConnectionStrings["MySqlStr"].ConnectionString;

        //连接数据库 
        MySqlConnection sqlCon = new MySqlConnection(sqlCconnStr);

        //建立DataSet对象(相当于建立前台的虚拟数据库)
        DataSet ds = new DataSet();

        //建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
        DataTable dtable;

        //建立DataRowCollection对象(相当于表的行的集合)
        DataRowCollection coldrow;

        //建立DataRow对象(相当于表的列的集合)
        DataRow drow;



        //打开连接
        sqlCon.Open();

        //建立DataAdapter对象  
        string sltStr = "select id,username,password from user ";//重点，重点，重点，查询出所有的字段
        MySqlCommand sqlCmd = new MySqlCommand(sltStr, sqlCon);
        //数据库数据适配器
        MySqlDataAdapter msda = new MySqlDataAdapter(sqlCmd);


        //建立 CommandBuilder 对象来自动生成 DataAdapter 的 Command 命令，否则就要自己编写
        //Insertcommand ,deletecommand , updatecommand 命令。
        MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(msda);


        //将查询的结果存到虚拟数据库ds中的虚拟表tabuser中
        msda.Fill(ds, "tabuser");

        //将数据表tabuser的数据复制到DataTable对象（取数据）
        dtable = ds.Tables["tabuser"];

        //用DataRowCollection对象获取这个数据表的所有数据行
        coldrow = dtable.Rows;


        //重点，重点，重点，重点，重点，重点,重点，重点，重点
        //update你的数据(update user password = 123321 where id = 1)
        for (int inti = 0; inti < coldrow.Count; inti++)//重点，重点，重点
        {
            drow = coldrow[inti];
            if (drow["id"].ToString() == 1 + "")
            {
                drow["password"] = "123321";
            }
        }

        msda.Update(ds, "tabuser");//重点，重点，重点，更新数据库


        sqlCon.Close();
        sqlCon = null;

    }



    public void delete(object sender, EventArgs e)
    {


        //获得Web.config中的配置信息
        string sqlCconnStr = ConfigurationManager.ConnectionStrings["MySqlStr"].ConnectionString;

        //连接数据库 
        MySqlConnection sqlCon = new MySqlConnection(sqlCconnStr);

        //建立DataSet对象(相当于建立前台的虚拟数据库)
        DataSet ds = new DataSet();

        //建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
        DataTable dtable;

        //建立DataRowCollection对象(相当于表的行的集合)
        DataRowCollection coldrow;

        //建立DataRow对象(相当于表的列的集合)
        DataRow drow;



        //打开连接
        sqlCon.Open();

        //建立DataAdapter对象  
        string sltStr = "select id,username,password from user ";//重点，重点，重点，查询出所有的字段
        MySqlCommand sqlCmd = new MySqlCommand(sltStr, sqlCon);
        MySqlDataAdapter msda = new MySqlDataAdapter(sqlCmd);


        //建立 CommandBuilder 对象来自动生成 DataAdapter 的 Command 命令，否则就要自己编写
        //Insertcommand ,deletecommand , updatecommand 命令。
        MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(msda);


        //将查询的结果存到虚拟数据库ds中的虚拟表tabuser中
        msda.Fill(ds, "tabuser");

        //将数据表tabuser的数据复制到DataTable对象（取数据）
        dtable = ds.Tables["tabuser"];

        //用DataRowCollection对象获取这个数据表的所有数据行
        coldrow = dtable.Rows;

        //逐行遍历，取出各行的数据,并且删除符合条件的数据（我要删除的id为4的记录）
        for (int inti = 0; inti < coldrow.Count; inti++)//重点，重点，重点，删除符合条件的数据
        {
            drow = coldrow[inti];
            if (drow["id"].ToString() == 4 + "")
            {
                drow.Delete();
            }
        }

        msda.Update(ds, "tabuser");//重点，重点，重点，更新数据库


        sqlCon.Close();
        sqlCon = null;


    }




    public void insert(object sender, EventArgs e)
    {



        //获得Web.config中的配置信息
        string sqlCconnStr = ConfigurationManager.ConnectionStrings["MySqlStr"].ConnectionString;

        //连接数据库 
        MySqlConnection sqlCon = new MySqlConnection(sqlCconnStr);

        //建立DataSet对象(相当于建立前台的虚拟数据库)
        DataSet ds = new DataSet();

        //建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
        DataTable dtable;



        //建立DataRow对象(相当于表的列的集合)
        DataRow drow;



        //打开连接
        sqlCon.Open();

        //建立DataAdapter对象  
        string sltStr = "select id,username,password from user ";//重点，重点，重点，查询出所有的数据
        MySqlCommand sqlCmd = new MySqlCommand(sltStr, sqlCon);
        MySqlDataAdapter msda = new MySqlDataAdapter(sqlCmd);


        //建立 CommandBuilder 对象来自动生成 DataAdapter 的 Command 命令，否则就要自己编写
        //Insertcommand ,deletecommand , updatecommand 命令。
        MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(msda);


        //将查询的结果存到虚拟数据库ds中的虚拟表tabuser中
        msda.Fill(ds, "tabuser");

        //将数据表tabuser的数据复制到DataTable对象（取数据）
        dtable = ds.Tables["tabuser"];

        //增加记录
        drow = ds.Tables["tabuser"].NewRow();

        //给该记录赋值
        drow[0] = 6;//重点，重点，重点，给id赋值
        drow[1] = "6";//重点，重点，重点，给username赋值
        drow[2] = "6";//重点，重点，重点，给password赋值

        ds.Tables["tabuser"].Rows.Add(drow);//重点，重点，重点，将记录添加的虚拟数据库





        //提交更新
        msda.Update(ds, "tabuser"); //重点，重点，重点，更新真正的数据库


        sqlCon.Close();
        sqlCon = null;


    }
}


