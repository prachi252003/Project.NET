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
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DbHelper dbHelper;
        public TrainerRepository()
        {
            dbHelper = new DbHelper();
        }

        public bool AddTrainer(Trainer trainer)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("AddTrainer", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", trainer.Name);
                cmd.Parameters.AddWithValue("@Type", trainer.Type);
                cmd.Parameters.AddWithValue("@Email", trainer.Email);
                cmd.Parameters.AddWithValue("@Phone", trainer.Phone);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                return rows > 0;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteTrainer(int id)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("DeleteTrainer", con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainerId",
                id);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TrainerNotFoundException();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<Trainer> GetAllTrainers()
        {
            try
            {
                List<Trainer> trainers =
                new List<Trainer>();

                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("GetAllTrainers", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                while (dr.Read())
                {
                    Trainer trainer =
                    new Trainer();

                    trainer.TrainerId =
                    Convert.ToInt32(dr["TrainerId"]);

                    trainer.Name =
                    dr["Name"].ToString();

                    trainer.Type =
                    Convert.ToChar(dr["Type"]);

                    trainer.Email =
                    dr["Email"].ToString();

                    trainer.Phone =
                    dr["Phone"].ToString();

                    trainers.Add(trainer);
                }

                con.Close();

                return trainers;
            }
            catch
            {
                throw;
            }
        }

        public Trainer GetTrainerById(int id)
        {
            try
            {
                Trainer trainer = null;

                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("GetTrainerById", con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainerId",
                id);

                con.Open();

                SqlDataReader dr =
                cmd.ExecuteReader();

                if (dr.Read())
                {
                    trainer = new Trainer();

                    trainer.TrainerId =
                    Convert.ToInt32(dr["TrainerId"]);

                    trainer.Name =
                    dr["Name"].ToString();

                    trainer.Type =
                    Convert.ToChar(dr["Type"]);

                    trainer.Email =
                    dr["Email"].ToString();

                    trainer.Phone =
                    dr["Phone"].ToString();
                }

                con.Close();

                if (trainer == null)
                    throw new TrainerNotFoundException();

                return trainer;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTrainer(Trainer trainer)
        {
            try
            {
                SqlConnection con = dbHelper.GetConnection();

                SqlCommand cmd =
                new SqlCommand("UpdateTrainer", con);

                cmd.CommandType =
                CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                "@TrainerId",
                trainer.TrainerId);

                cmd.Parameters.AddWithValue(
                "@Name",
                trainer.Name);

                cmd.Parameters.AddWithValue(
                "@Type",
                trainer.Type);

                cmd.Parameters.AddWithValue(
                "@Email",
                trainer.Email);

                cmd.Parameters.AddWithValue(
                "@Phone",
                trainer.Phone);

                con.Open();

                int rows =
                cmd.ExecuteNonQuery();

                con.Close();

                if (rows == 0)
                    throw new TrainerNotFoundException();

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
