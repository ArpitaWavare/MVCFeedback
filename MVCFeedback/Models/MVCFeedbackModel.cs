using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCFeedback.Data;

namespace MVCFeedback.Models
{
    public class MVCFeedbackModel
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Age { get; set; }
        public string Email_id { get; set; }
        public string Address { get; set; }

        public int Srno { get; set; }
        public string Savereg(MVCFeedbackModel model)
        {
            string msg = "Save";

            MVCFeedbackEntities Db = new MVCFeedbackEntities();
            var MVCFeedback = Db.MVCFeedbacks.Where(p => p.Id == model.Id).FirstOrDefault();

            if (model.Id == 0)
            {
                var MVCFeedbackData = new Data.MVCFeedback()
                {

                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    Age = model.Age,
                    Email_id = model.Email_id,
                    Address = model.Address,
                };
                Db.MVCFeedbacks.Add(MVCFeedbackData);
                Db.SaveChanges();
                
            }
            else
            {
                MVCFeedback.Id = model.Id;
                MVCFeedback.First_Name = model.First_Name;
                MVCFeedback.Last_Name = model.Last_Name;
                MVCFeedback.Age = model.Age;
                MVCFeedback.Email_id = model.Email_id;
                MVCFeedback.Address = model.Address;

                Db.SaveChanges();
                msg = "update successfully";
            }
            return msg;

        }
        public List <MVCFeedbackModel> GetMVCFeedbackList()
        {
            MVCFeedbackEntities Db = new MVCFeedbackEntities();
            List<MVCFeedbackModel> lstMVCFeedbacks = new List<MVCFeedbackModel>();
            var AddMVCFeedbackList = Db.MVCFeedbacks.ToList();
            int Srno = 1;

            if (AddMVCFeedbackList != null)
            {
                foreach (var MVCFeedback in AddMVCFeedbackList)
                {
                    lstMVCFeedbacks.Add(new MVCFeedbackModel()
                    {
                        Srno = Srno,
                        Id = MVCFeedback.Id,
                        First_Name = MVCFeedback.First_Name,
                        Last_Name = MVCFeedback.Last_Name,
                        Age = MVCFeedback.Age,
                        Email_id = MVCFeedback.Email_id,
                        Address = MVCFeedback.Address,
                    });
                    Srno++;
                }
            }
            return lstMVCFeedbacks;

        }
        public string deleteMVCFeedback(int Id)
        {
            var msg = "delete successfull";
            MVCFeedbackEntities Db = new MVCFeedbackEntities();
            var data = Db.MVCFeedbacks.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                Db.MVCFeedbacks.Remove(data);
                Db.SaveChanges();

            }
            return msg;
        }

        public MVCFeedbackModel getMVCFeedbackbyId(int Id)
        {
            MVCFeedbackModel model = new MVCFeedbackModel();
            MVCFeedbackEntities Db = new MVCFeedbackEntities();
            var data = Db.MVCFeedbacks.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                model.Id = data.Id;
                model.First_Name = data.First_Name;
                model.Last_Name = data.Last_Name;
                model.Age = data.Age;
                model.Email_id = data.Email_id;
                model.Address = data.Address;
                

            }
            return model;
        }


    }

}
