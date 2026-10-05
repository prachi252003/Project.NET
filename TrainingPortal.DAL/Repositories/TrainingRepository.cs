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
    public class TrainingRepository : ITrainingRepository
    {
        private readonly DbHelper dbHelper;

        public TrainingRepository()
        {
            dbHelper = new DbHelper();
        }

        public bool AddTraining(Training training)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("AddTraining", con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainerId",
                training.TrainerId);

                cmd.Parameters.AddWithValue(
                "@TechnologyId",
                training.TechnologyId);

                cmd.Parameters.AddWithValue(
                "@StartDate",
                training.StartDate);

                cmd.Parameters.AddWithValue(
                "@EndDate",
                training.EndDate);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                return rows > 0;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteTraining(int id)
        {
            try
            {
                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "DeleteTraining",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                id);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TrainingNotFoundException();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<Training> GetAllTrainings()
        {
            try
            {
                List<Training> trainings =
                new List<Training>();

                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "GetAllTrainings",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                while (dr.Read())
                {
                    Training training =
                    new Training();

                    training.TrainingId =
                    Convert.ToInt32(
                    dr["TrainingId"]);

                    training.TrainerId =
                    Convert.ToInt32(
                    dr["TrainerId"]);

                    training.TechnologyId =
                    Convert.ToInt32(
                    dr["TechnologyId"]);

                    training.StartDate =
                    Convert.ToDateTime(
                    dr["StartDate"]);

                    training.EndDate =
                    Convert.ToDateTime(
                    dr["EndDate"]);

                    trainings.Add(training);
                }

                con.Close();

                return trainings;
            }
            catch
            {
                throw;
            }
        }

        public Training GetTrainingById(int id)
        {
            try
            {
                Training training = null;

                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "GetTrainingById",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                id);

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                if (dr.Read())
                {
                    training =
                    new Training();

                    training.TrainingId =
                    Convert.ToInt32(
                    dr["TrainingId"]);

                    training.TrainerId =
                    Convert.ToInt32(
                    dr["TrainerId"]);

                    training.TechnologyId =
                    Convert.ToInt32(
                    dr["TechnologyId"]);

                    training.StartDate =
                    Convert.ToDateTime(
                    dr["StartDate"]);

                    training.EndDate =
                    Convert.ToDateTime(
                    dr["EndDate"]);
                }

                con.Close();

                if (training == null)
                    throw new TrainingNotFoundException();

                return training;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTraining(Training training)
        {
            try
            {
                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "UpdateTraining",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                training.TrainingId);

                cmd.Parameters.AddWithValue(
                "@TrainerId",
                training.TrainerId);

                cmd.Parameters.AddWithValue(
                "@TechnologyId",
                training.TechnologyId);

                cmd.Parameters.AddWithValue(
                "@StartDate",
                training.StartDate);

                cmd.Parameters.AddWithValue(
                "@EndDate",
                training.EndDate);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TrainingNotFoundException();

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
