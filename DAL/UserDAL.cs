using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        public static bool Register(User user)
        {

            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {


                    db1.Users.Add(user);
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static User Login(string usercode, string password)
        {

            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    User user = db1.Users.Where(p => p.email == usercode && p.pasword == password).FirstOrDefault();
                    if (user != null)
                        return user;
                    return null;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static bool DeletePlayer(int userId)
        {

            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    db1.Users.Remove(db1.Users.Where(u => u.userId == userId).FirstOrDefault());
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static  string getNameUser(int id)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    return db1.Users.Where(u => u.userId == id).FirstOrDefault().fullName.ToString();
                   
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }


    }



}

