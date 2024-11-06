using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace WindowsFormsApp2
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=E:/Database/identifier.sqlite;Version=3;";

        // 添加学校
        public static void AddSchool(School school)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Schools (Name, Address) VALUES (@name, @address)", connection);
                command.Parameters.AddWithValue("@name", school.Name);
                command.Parameters.AddWithValue("@address", school.Address);
                command.ExecuteNonQuery();
                LogAction($"Added School: {school.Name}");
            }
        }

        // 添加班级
        public static void AddClass(Class classObj)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Classes (ClassName, SchoolId) VALUES (@className, @schoolId)", connection);
                command.Parameters.AddWithValue("@className", classObj.ClassName);
                command.Parameters.AddWithValue("@schoolId", classObj.SchoolId);
                command.ExecuteNonQuery();
                LogAction($"Added Class: {classObj.ClassName}");
            }
        }

        // 添加学生
        public static void AddStudent(Student student)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Students (Name, ClassId,Age) VALUES (@name, @classId,@Age)", connection);
                command.Parameters.AddWithValue("@name", student.Name);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@classId", student.ClassId);

                command.ExecuteNonQuery();
                LogAction($"Added Student: {student.Name}");
            }
        }

        // 更新学生信息
        public static void UpdateStudentInfo(int StudentId, string newName, string newAge)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Students SET Name = @newName, Age = @newAge WHERE StudentId = @StudentId", connection);
                command.Parameters.AddWithValue("@newName", newName);
                command.Parameters.AddWithValue("@newAge", newAge);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                command.ExecuteNonQuery();
                LogAction($"Updated Student ID: {StudentId} to Name: {newName}, Age: {newAge}");
            }
        }
        //更新班级信息
        public static void UpdateClass(int ClassId, string ClassName)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Classes SET ClassName = @ClassName WHERE ClassId = @ClassId", connection);
                command.Parameters.AddWithValue("@ClassName", ClassName);
                command.Parameters.AddWithValue("@ClassId", ClassId);
                command.ExecuteNonQuery();
                LogAction($"Updated Class ID: {ClassId} to Name: {ClassName}");
            }
        }


        public static void LogAction(string action)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Log (Action) VALUES (@action)", connection);
                command.Parameters.AddWithValue("@action", action);
                command.ExecuteNonQuery();
            }
        }

        public static School GetSchoolById(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Schools WHERE SchoolId = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var school = new School
                        {
                            SchoolId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2)
                        };
                        return school;
                    }
                }
            }
            return null;
        }
            //创建学校
            public static void CreateSchool(string name, string address)
        {
            var school = new School
            {
                Name = name,
                Address = address
            };
            AddSchool(school);
        }

        //获取学校列表
        public static List<School> GetSchoolsFromDatabase()
        {
            var schools = new List<School>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Schools", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var school = new School
                        {
                            SchoolId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2)
                        };
                        schools.Add(school);
                    }
                }

                return schools;
            }
        }
        //获取班级列表

        public static List<Class> GetClassesFromDatabase()
        {
            var classes = new List<Class>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Classes", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var classObj = new Class
                        {
                            ClassId = reader.GetInt32(0),
                            ClassName = reader.GetString(1),
                            SchoolId = reader.GetInt32(2)
                        };
                        classes.Add(classObj);
                    }
                }
            }

            return classes;
        }

        public static List<Class> GetClassesBySchoolId(int schoolId)
        {
            var classes = new List<Class>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Classes WHERE SchoolId = @schoolId", connection);
                command.Parameters.AddWithValue("@schoolId", schoolId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var classObj = new Class
                        {
                            ClassId = reader.GetInt32(0),
                            ClassName = reader.GetString(1),
                            SchoolId = reader.GetInt32(2)
                        };
                        classes.Add(classObj);
                    }
                }
            }

            return classes;
        }

        public static List<Student> GetStudentsByClassId(int classId)
        {
            var students = new List<Student>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Students WHERE ClassId = @classId", connection);
                command.Parameters.AddWithValue("@classId", classId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            StudentId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Age = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            ClassId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                        };
                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public static void UpdateSchoolInfo(string selectedSchoolName, string newName, string newInfo)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Schools SET Name = @newName, Address = @newInfo WHERE Name = @selectedSchoolName", connection);
                command.Parameters.AddWithValue("@newName", newName);
                command.Parameters.AddWithValue("@newInfo", newInfo);
                command.Parameters.AddWithValue("@selectedSchoolName", selectedSchoolName);
                command.ExecuteNonQuery();
                LogAction($"Updated School: {selectedSchoolName} to {newName}");
            }
        }

        //获取班级id
        public static string GetClassIdbyName(string className)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT ClassId FROM Classes WHERE ClassName = @className", connection);
                command.Parameters.AddWithValue("@className", className);
                var result = command.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }


        // 删除学校以及该学校的所有班级和学生
        public static void DeleteSchool(int schoolId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // 先删除该学校的所有学生
                var deleteStudentsCommand = new SQLiteCommand("DELETE FROM Students WHERE ClassId IN (SELECT ClassId FROM Classes WHERE SchoolId = @schoolId)", connection);
                deleteStudentsCommand.Parameters.AddWithValue("@schoolId", schoolId);
                deleteStudentsCommand.ExecuteNonQuery();

                // 然后删除该学校的所有班级
                var deleteClassesCommand = new SQLiteCommand("DELETE FROM Classes WHERE SchoolId = @schoolId", connection);
                deleteClassesCommand.Parameters.AddWithValue("@schoolId", schoolId);
                deleteClassesCommand.ExecuteNonQuery();

                // 最后删除学校
                var deleteSchoolCommand = new SQLiteCommand("DELETE FROM Schools WHERE SchoolId = @schoolId", connection);
                deleteSchoolCommand.Parameters.AddWithValue("@schoolId", schoolId);
                deleteSchoolCommand.ExecuteNonQuery();

                LogAction($"Deleted School ID: {schoolId}");
            }
        }

        // 删除班级以及该班级的所有学生
        public static void DeleteClass(int classId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // 先删除该班级的所有学生
                var deleteStudentsCommand = new SQLiteCommand("DELETE FROM Students WHERE ClassId = @classId", connection);
                deleteStudentsCommand.Parameters.AddWithValue("@classId", classId);
                deleteStudentsCommand.ExecuteNonQuery();

                // 然后删除班级
                var deleteClassCommand = new SQLiteCommand("DELETE FROM Classes WHERE ClassId = @classId", connection);
                deleteClassCommand.Parameters.AddWithValue("@classId", classId);
                deleteClassCommand.ExecuteNonQuery();

                LogAction($"Deleted Class ID: {classId}");
            }
        }

        // 删除学生
        public static void DeleteStudent(int studentId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Students WHERE StudentId = @studentId", connection);
                command.Parameters.AddWithValue("@studentId", studentId);
                command.ExecuteNonQuery();
                LogAction($"Deleted Student ID: {studentId}");
            }
        }
        public static DataTable GetLogs()
        {
            DataTable logTable = new DataTable();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Log", connection);
                using (var reader = command.ExecuteReader())
                {
                    logTable.Load(reader);
                }
            }
            return logTable;
        }
    }
}
