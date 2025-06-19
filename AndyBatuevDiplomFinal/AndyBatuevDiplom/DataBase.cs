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
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;Trust Server Certificate=True");
        // CREATE DATABASE BatuevDiplom
        // CREATE TABLE users(id int NOT NULL IDENTITY (1,1) , NameLogin varchar(50) NOT NULL, pass varchar(50), firstName varchar(50), surName varchar(50), otchestvo varchar(50), serPass varchar(50), numPass varchar(50), PolisOMS varchar(50), Snils varchar(50))
        // CREATE TABLE zapis(idClient int NOT NULL, dateZapis datetime NOT NULL, doctorName varchar(50), doctorSpec varchar(50))
       
        // INSERT INTO users (name, password) VALUES ('admin', 'abc')

        // CREATE TABLE registrationSessions (idSession int NOT NULL IDENTITY (1,1) ,userID int NOT NULL, name varchar (50) NOT NULL, talon int NOT NULL,dateSession date )
        // INSERT INTO registrationSessions (userID, name, talon, dateSession) VALUES (1, 'admin', 1, '2020-10-20')

        // CREATE TABLE employeeAndAdmins (id int NOT NULL IDENTITY (1,1) , name varchar (50) NOT NULL, password varchar (50), Admin bit)



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
