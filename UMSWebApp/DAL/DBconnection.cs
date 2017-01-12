using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UMSWebApp.DAL
{
    abstract public class DBconnection
    {
        protected SqlConnection Connection;
        protected SqlCommand Command;
        protected SqlDataAdapter Adapter;
        protected SqlDataReader Reader;

        protected DBconnection()
        {
            Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}