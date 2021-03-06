using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {
        private int _studentId;
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.path, Program.xmlJsonChangerB);
        private Student _student;
        private List<Group> _groups;
        public AddEditStudent(int id = 0)
        {
            InitializeComponent();
            _studentId = id;
            
            _groups = GroupsHelper.GetGroups("Brak");
            InitGroupsComboBox();

            GetStudentData();

            tbName.Select();
        }
        private void InitGroupsComboBox()
        {
            cmbGroup.DataSource = _groups;
            cmbGroup.DisplayMember = "GroupName";
            cmbGroup.ValueMember = "Id";
        }
        private void GetStudentData()
        {
            if (_studentId != 0)
            {
                this.Text = "Edytowanie ucznia";
                var students = _fileHelper.DeserializerFromFile();
                _student = students.FirstOrDefault(x => x.Id == _studentId);
                if (_student == null)
                    throw new Exception("Brak użytkownika o podanym ID");
                FillTextBox();
            }
        }
        private void FillTextBox()
        {
            tbID.Text = _student.Id.ToString();
            tbName.Text = _student.Name;
            tbSurname.Text = _student.Surname;
            tbMath.Text = _student.Math;
            tbPolish.Text = _student.LangPolish;
            tbEnglish.Text = _student.LangEnglish;
            rtbComments.Text = _student.Comments;
            ckbAdditionalLessons.Checked = _student.AdditionalLesson;
            cmbGroup.SelectedItem = _groups.FirstOrDefault(x => x.Id == _student.IdGroup);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializerFromFile();

            if (_studentId != 0)
                students.RemoveAll(x => x.Id == _studentId);
            else
                AssignIdToNewStudent(students);

            AddNewUserToList(students);

            _fileHelper.SerializeToFile(students);

            Close();
        }
        private void AddNewUserToList(List<Student> students)
        {
            var student = new Student
            {
                IdGroup = (cmbGroup.SelectedItem as Group).Id,
                Id = _studentId,
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Math = tbMath.Text,
                LangPolish = tbPolish.Text,
                LangEnglish = tbEnglish.Text,
                Comments = rtbComments.Text,
                AdditionalLesson = ckbAdditionalLessons.Checked
            };

            students.Add(student);
        }
        private void AssignIdToNewStudent(List<Student> students)
        {
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();

            if (studentWithHighestId == null)
                _studentId = 1;
            else
                _studentId = studentWithHighestId.Id + 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
