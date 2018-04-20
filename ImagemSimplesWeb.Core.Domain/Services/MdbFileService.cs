using ImagemSimplesWeb.Core.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Core.Domain.Services
{
    public class MdbFileService : IMdbFileService
    {
        public DataTable RetornaArquivo(string path, string query)
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;"
        + "Data Source= " + path + " ;";
            var Myconnection = new OleDbConnection(con);
            if (query.Length > 0 )
            {
                query = " where " + query;
            }
            DataSet myDataSet = new DataSet();
            OleDbCommand myAccessCommand = new OleDbCommand("select * from Indices " + query, Myconnection);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

            // Open connection
            Myconnection.Open();

            myDataAdapter.Fill(myDataSet, "Indices");
            DataTable dt = new DataTable();
            dt = myDataSet.Tables["Indices"];

            return dt;
        }

        public void AlterarArquivo(string fullName)
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;"
        + "Data Source= " + fullName + " ;";
            var Myconnection = new OleDbConnection(con);

            DataSet myDataSet = new DataSet();
            OleDbCommand myAccessCommand = new OleDbCommand("alter table Indices add path_documento varchar(200) ", Myconnection);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

            // Open connection
            Myconnection.Open();


            myDataAdapter.Fill(myDataSet, "Indices");
            DataTable dt = new DataTable();
            dt = myDataSet.Tables["Indices"];
            Myconnection.Close();
        }

        public void UpdatePath(string fullName)
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source= " + fullName + " ;";
            var Myconnection = new OleDbConnection(con);

            DataSet myDataSet = new DataSet();
            OleDbCommand myAccessCommand = new OleDbCommand("update INDICES set path_documento = Replace([path_imagem],'a','b')", Myconnection);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

            // Open connection
            Myconnection.Open();


            myDataAdapter.Fill(myDataSet, "Indices");
            DataTable dt = new DataTable();
            dt = myDataSet.Tables["Indices"];
            Myconnection.Close();
        }
    }
}
