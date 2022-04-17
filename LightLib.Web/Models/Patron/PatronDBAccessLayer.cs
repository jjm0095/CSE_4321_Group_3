using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using LightLib.Web.Models.Patron;
using Npgsql;

namespace LightLib.Web.Models.Patron
{
    public class PatronDBAccessLayer
    {
       
        public string AddPatron(Data.Models.Patron patron)
        { 
            var cs = "Host=localhost;Username=postgres;Password=soccer01!Database=lightlib_dev";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "INSERT INTO public.patrons(\"Id\", \"FirstName\", \"LastName\", \"Address\", \"DateOfBirth\", \"Email\", \"Telephone\", \"LibraryCardId\", \"HomeLibraryBranchId\", \"CreatedOn\", \"UpdatedOn\") VALUES";
            using var cmd = new NpgsqlCommand(sql, con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", patron.Id);
            cmd.Parameters.AddWithValue("@FirstName", patron.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patron.LastName);
            cmd.Parameters.AddWithValue("@Address", patron.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", patron.DateOfBirth);
            cmd.Parameters.AddWithValue("@Email", patron.Email);
            cmd.Parameters.AddWithValue("@Telephone", patron.Telephone);
            cmd.Parameters.AddWithValue("@LibraryCardId", patron.LibraryCard);
            cmd.Parameters.AddWithValue("@HomeLibraryBranchId", patron.HomeLibraryBranch);
            cmd.Parameters.AddWithValue("@CreatedOn", patron.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedOn", patron.UpdatedOn);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return ("Data save Successfully");
        }
    }
}
