using SchoolManagementSystem.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var schools = new List<School>();
            // int num = 0;

            var observableSchools = Observable.Generate(1, i => i <= 3, i => i + 1, i =>
            {
                var school = new School(string.Format($"School {i}"));
                school.FillWithStudents(10);

                schools.Add(school);

                return school;
            });

            observableSchools.Subscribe();

            //observableSchools.ObserveOn(this).Subscribe((School school) =>
            //{
            
            //    var control = this.Controls.Find(string.Format($"lstSchool{++num}"), true)?.FirstOrDefault();
            //    if (control != null)
            //    {
            //        var lst = control as ListBox;
            //        if (lst != null)
            //        {
            //            lst.Items.Clear();
            //            lst.Items.Add(school.Name);

            //            foreach (var student in school.Take(10))
            //            {
            //                lst.Items.Add(student.ToString());
            //            }
            //        }
            //    }
            //});
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var query = Observable.FromEvent<NewStudentAdmittedEventArgs>
                (ev => School.StudentAdmitted += ev,
                ev => School.StudentAdmitted -= ev);

            query.Subscribe(args => 
            {
                lst.Items.Add(args.Student.ToString());
            });
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
