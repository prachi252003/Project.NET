using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using TrainingPortal.DAL.DBUtility;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.Entities.Models;
using TrainingPortal.Exceptions.CustomExceptions;

namespace TrainingPortal.DAL.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly DbHelper dbHelper;

        public TechnologyRepository()
        {
            dbHelper = new DbHelper();
        }
        public bool AddTechnology(Technology technology)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                    new SqlCommand("AddTechnology", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", technology.Name);
                cmd.Parameters.AddWithValue("@Level", technology.Level);
                cmd.Parameters.AddWithValue("@Duration", technology.Duration);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Technology> GetAllTechnologies()
        {
            try
            {
                List<Technology> technologies =
                    new List<Technology>();

                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                    new SqlCommand("GetAllTechnologies", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Technology tech =
                        new Technology();

                    tech.TechnologyId =
                        Convert.ToInt32(dr["TechnologyId"]);

                    tech.Name =
                        dr["Name"].ToString();

                    tech.Level =
                        Convert.ToChar(dr["Level"]);

                    tech.Duration =
                        Convert.ToInt32(dr["Duration"]);

                    technologies.Add(tech);
                }

                con.Close();

                return technologies;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Technology GetTechnologyById(int technologyId)
        {
            try
            {
                Technology tech = null;

                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                    new SqlCommand("GetTechnologyById", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@TechnologyId",
                    technologyId);

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    tech = new Technology();

                    tech.TechnologyId =
                        Convert.ToInt32(dr["TechnologyId"]);

                    tech.Name =
                        dr["Name"].ToString();

                    tech.Level =
                        Convert.ToChar(dr["Level"]);

                    tech.Duration =
                        Convert.ToInt32(dr["Duration"]);
                }

                con.Close();

                if (tech == null)
                    throw new TechnologyNotFoundException();

                return tech;
            }
            catch (Exception ex) { throw ex; }
        }
        public bool UpdateTechnology(Technology technology)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                    new SqlCommand("UpdateTechnology", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@TechnologyId",
                    technology.TechnologyId);

                cmd.Parameters.AddWithValue(
                    "@Name",
                    technology.Name);

                cmd.Parameters.AddWithValue(
                    "@Level",
                    technology.Level);

                cmd.Parameters.AddWithValue(
                    "@Duration",
                    technology.Duration);

                con.Open();

                int rows =
                    cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TechnologyNotFoundException();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteTechnology(int technologyId)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                    new SqlCommand("DeleteTechnology", con);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@TechnologyId",
                    technologyId);

                con.Open();

                int rows =
                    cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TechnologyNotFoundException();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
