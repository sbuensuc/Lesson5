using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are required to connect to EF DB
using Lesson5.Models;
using System.Web.ModelBinding;

namespace Lesson5
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if im loading the page for the first time
            //populate student grid
            if (!IsPostBack)
            {
                //get the student data
                this.GetStudents();
            }
        }

        /// <summary>
        /// This method gets the student data from db
        /// </summary>

        private void GetStudents()
        {
            //connect to EF DB
            using (ContosoContext db = new ContosoContext())
            {
                //query the student table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                //bind the result to the Students GridView
                StudentsGridView.DataSource = Students.ToList();
                StudentsGridView.DataBind();
            }
        }
    }
}