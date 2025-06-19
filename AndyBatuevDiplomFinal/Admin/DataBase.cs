using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Admin
{
    class DataBase
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True");
        //DESKTOP-45KAQVQ\SQLEXPRESS
        //DESKTOP-GV5R2EO

        // CREATE DATABASE ZaharovaUsers
        // CREATE TABLE users (id int NOT NULL IDENTITY (1,1) , name varchar (50) NOT NULL, password varchar (50) )
        // INSERT INTO users (name, password) VALUES ('admin', 'abc')

        // CREATE TABLE registrationSessions (idSession int NOT NULL IDENTITY (1,1) ,userID int NOT NULL, name varchar (50) NOT NULL, talon int NOT NULL,dateSession date )
        // INSERT INTO registrationSessions (userID, name, talon, dateSession) VALUES (1, 'admin', 1, '2020-10-20')

        //
        //




        public void openConnection()
        {
            sqlCon.Open();
        }
        public void closeConnection()
        {
            sqlCon.Close();
        }

        public SqlConnection getConnection()
        {
            return sqlCon;
        }
    }
}