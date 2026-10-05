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
    public class TraineeRepository : ITraineeRepository
    {
        private readonly DbHelper dbHelper;
        public TraineeRepository()
        {
            dbHelper = new DbHelper();
        }
        public bool AddTrainee(Trainee trainee)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("AddTrainee", con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                trainee.TrainingId);

                cmd.Parameters.AddWithValue(
                "@EmpId",
                trainee.EmpId);

                cmd.Parameters.AddWithValue(
                "@Status",
                trainee.Status);

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

        public bool DeleteTrainee(int trainingId, int empId)
        {
            try
            {
                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "DeleteTrainee",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                trainingId);

                cmd.Parameters.AddWithValue(
                "@EmpId",
                empId);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TraineeNotFoundException();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<Trainee> GetAllTrainees()
        {
            try
            {
                List<Trainee> trainees =
                new List<Trainee>();

                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "GetAllTrainees",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                while (dr.Read())
                {
                    Trainee trainee =
                    new Trainee();

                    trainee.TrainingId =
                    Convert.ToInt32(
                    dr["TrainingId"]);

                    trainee.EmpId =
                    Convert.ToInt32(
                    dr["EmpId"]);

                    trainee.Status =
                    Convert.ToChar(
                    dr["Status"]);

                    trainees.Add(trainee);
                }

                con.Close();

                return trainees;
            }
            catch
            {
                throw;
            }
        }

        public Trainee GetTraineeById(int trainingId, int empId)
        {
            try
            {
                Trainee trainee = null;

                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "GetTraineeById",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                trainingId);

                cmd.Parameters.AddWithValue(
                "@EmpId",
                empId);

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                if (dr.Read())
                {
                    trainee =
                    new Trainee();

                    trainee.TrainingId =
                    Convert.ToInt32(
                    dr["TrainingId"]);

                    trainee.EmpId =
                    Convert.ToInt32(
                    dr["EmpId"]);

                    trainee.Status =
                    Convert.ToChar(
                    dr["Status"]);
                }

                con.Close();

                if (trainee == null)
                    throw new TraineeNotFoundException();

                return trainee;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            try
            {
                SqlConnection con =
                dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand(
                "UpdateTrainee",
                con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainingId",
                trainee.TrainingId);

                cmd.Parameters.AddWithValue(
                "@EmpId",
                trainee.EmpId);

                cmd.Parameters.AddWithValue(
                "@Status",
                trainee.Status);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TraineeNotFoundException();

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
