using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace L101Exercises1
{
    class StudentManagermentUtils
    {
        private static string STUDENT_FILE_NAME = "student.json";
        private static string SUBJECT_FILE_NAME = "subject.json";
        private static string REGISTER_FILE_NAME = "register.json";

        private IFilter filter = null;
        private IOController controller = null;
        public StudentManagermentUtils()
        {
            filter = new Filter();
            controller = new IOController();
        }

        // tạo thông tin đăng ký fake
        public void CreateFakeRegisters(List<Register> registers,
                                        List<Student> students, List<Subject> subjects)
        {
            registers.Add(new Register(0, students[0], subjects[0], DateTime.Now));
            registers.Add(new Register(0, students[1], subjects[0], DateTime.Now));
            registers.Add(new Register(0, students[2], subjects[0], DateTime.Now));
            registers.Add(new Register(0, students[3], subjects[0], DateTime.Now));
            registers.Add(new Register(0, students[4], subjects[0], DateTime.Now));
            registers.Add(new Register(0, students[0], subjects[5], DateTime.Now));
            registers.Add(new Register(0, students[1], subjects[2], DateTime.Now));
            registers.Add(new Register(0, students[2], subjects[1], DateTime.Now));
            registers.Add(new Register(0, students[3], subjects[3], DateTime.Now));
            registers.Add(new Register(0, students[4], subjects[4], DateTime.Now));
            registers.Add(new Register(0, students[1], subjects[1], DateTime.Now));
            registers.Add(new Register(0, students[1], subjects[5], DateTime.Now));
            registers.Add(new Register(0, students[0], subjects[1], DateTime.Now));
            registers.Add(new Register(0, students[0], subjects[2], DateTime.Now));
            registers.Add(new Register(0, students[0], subjects[3], DateTime.Now));
        }

        // kiểm tra xem một bản đăng ký đã tồn tại trước đó chưa
        public bool Contains(List<Register> registers, Register newRegister)
        {
            foreach (var item in registers)
            {
                if (item != null && item.Equals(newRegister))
                {
                    return true;
                }
            }
            return false;
        }

        // ghi dữ liệu sinh viên ra file
        public void SaveStudentData(List<Student> students)
        {
            controller.SaveStudentsData(students, STUDENT_FILE_NAME);
        }

        // ghi dữ liệu môn học ra file
        public void SaveSubjectData(List<Subject> subjects)
        {
            controller.SaveSubjectsData(subjects, SUBJECT_FILE_NAME);
        }

        // ghi dữ liệu đăng ký ra file
        public void SaveRegisterData(List<Register> registers)
        {
            controller.SaveRegistersData(registers, REGISTER_FILE_NAME);
        }

        // đọc file sinh viên
        public void GetStudents(List<Student> students)
        {
            try
            {
                students.AddRange(controller.GetStudents(STUDENT_FILE_NAME));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }

        // đọc file môn học
        public void GetSubjects(List<Subject> subjects)
        {
            try
            {
                subjects.AddRange(controller.GetSubjects(SUBJECT_FILE_NAME));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }

        // đọc file đăng ký
        public void GetRegisters(List<Register> registers)
        {
            try
            {
                registers.AddRange(controller.GetRegisters(REGISTER_FILE_NAME));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }

        // cập nhật mã tự động tăng cho môn học
        public void UpdateSubjectAutoId(List<Subject> subjects)
        {
            controller.UpdateSubjectAutoId(subjects);
        }

        // cập nhật mã tự tăng của bảng đăng ký
        public void UpdateRegisterAutoId(List<Register> registers)
        {
            controller.UpdateRegisterAutoId(registers);
        }

        // tạo thông tin môn học fake
        public void CreateFakeSubjects(List<Subject> subjects)
        {
            subjects.Add(new Subject(0, "C++", 3, 36));
            subjects.Add(new Subject(0, "C", 3, 36));
            subjects.Add(new Subject(0, "C#", 4, 48));
            subjects.Add(new Subject(0, "Java", 4, 46));
            subjects.Add(new Subject(0, "Kotlin", 3, 36));
            subjects.Add(new Subject(0, "Android", 5, 60));
            subjects.Add(new Subject(0, "SQL", 3, 36));
            subjects.Add(new Subject(0, "Python", 4, 48));
            subjects.Add(new Subject(0, "JavaScript", 3, 36));
            subjects.Add(new Subject(0, "Web design", 2, 25));
        }

        // tạo danh sách sinh viên fake
        public void CreateFakeStudents(List<Student> students)
        {
            var dateFormat = "dd/MM/yyyy";
            students.Add(new Student("B25DCCN101", "Trần Văn Nam", DateTime.ParseExact("15/06/2007", dateFormat, null), "vannam@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN103", "Ngô Văn Tài", DateTime.ParseExact("15/04/2007", dateFormat, null), "vantai123@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN102", "Hồ Hoàng Yến", DateTime.ParseExact("27/07/2007", dateFormat, null), "hoangyenkk@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN105", "Võ Hoàng Yến", DateTime.ParseExact("11/09/2007", dateFormat, null), "yenvo@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN104", "Vy Thị Yến", DateTime.ParseExact("14/02/2007", dateFormat, null), "yenvi@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN108", "Mai Văn Dũng", DateTime.ParseExact("19/08/2007", dateFormat, null), "vandung@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN107", "Lê Thanh Thảo", DateTime.ParseExact("18/09/2007", dateFormat, null), "thanhthao@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN106", "Ngô Nhật Phong", DateTime.ParseExact("10/10/2007", dateFormat, null), "nhatphong@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN109", "Ma Thanh Thức", DateTime.ParseExact("16/11/2007", dateFormat, null), "thanhthuc@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN111", "Khúc Thị Lệ Quyên", DateTime.ParseExact("18/12/2007", dateFormat, null), "lequyenkhuc@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN110", "Trương Trọng Anh", DateTime.ParseExact("17/05/2007", dateFormat, null), "tronganhtruong@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN112", "Nguyễn Quỳnh Anh", DateTime.ParseExact("25/01/2007", dateFormat, null), "quynhanhng@xmail.com", "0912365211", "CNTT"));
            students.Add(new Student("B25DCCN115", "Thân Văn Huấn", DateTime.ParseExact("30/04/2007", dateFormat, null), "vanhuanth@xmail.com", "0912365211", "CNTT"));
        }

        // tìm bản đăng ký theo mã môn học
        public List<Register> FindRegisterBySubjectId(List<Register> registers)
        {
            var result = new List<Register>();
            Console.WriteLine("Mã môn học cần tìm: ");
            var subjectIdStr = Console.ReadLine();
            if (!filter.IsSubjectIdValid(subjectIdStr))
            {
                throw new InvalidSubjectIdException("Mã môn học không hợp lệ.", subjectIdStr);
            }
            var subjectId = int.Parse(subjectIdStr);
            foreach (var item in registers)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Subject.SubjectId == subjectId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // tạo mới bản đăng ký
        public Register CreateRegister(List<Student> students, List<Subject> subjects)
        {
            Console.WriteLine("Mã sinh viên đăng ký: ");
            var studentId = Console.ReadLine().ToUpper();
            if (!filter.IsStudentIdValid(studentId))
            {
                var message = "Mã sinh viên không hợp lệ.";
                throw new InvalidStudentIdException(message, studentId);
            }
            Console.WriteLine("Mã môn học được chọn: ");
            var subjectIdString = Console.ReadLine();
            if (!filter.IsSubjectIdValid(subjectIdString))
            {
                var msg = "Mã môn học không hợp lệ.";
                throw new InvalidSubjectIdException(msg, subjectIdString);
            }
            var subjectId = int.Parse(subjectIdString);
            var registerTime = DateTime.Now;
            var studentIndex = FindStudentIndexById(students, studentId);
            var subjectIndex = FindSubjectIndexById(subjects, subjectId);
            var subject = subjectIndex == -1 ? null : subjects[subjectIndex];
            var student = studentIndex == -1 ? null : students[studentIndex];
            return new Register(0, student, subject, registerTime);
        }

        // tạo mới môn học
        public Subject CreateSubject()
        {
            Console.WriteLine("Tên môn học: ");
            var name = Console.ReadLine();
            Console.WriteLine("Số tín chỉ: ");
            var credit = int.Parse(Console.ReadLine());
            Console.WriteLine("Số tiết học: ");
            var lesson = int.Parse(Console.ReadLine());
            return new Subject(0, name, credit, lesson);
        }

        // tạo mới sinh viên
        public Student CreateStudent(List<Student> students)
        {
            Console.WriteLine("Mã sinh viên dạng B25DCCN001: ");
            var studentId = Console.ReadLine().ToUpper().Trim();
            if (!filter.IsStudentIdValid(studentId))
            {
                var msg = "Mã sinh viên không hợp lệ.";
                throw new InvalidStudentIdException(msg, studentId);
            }
            else
            {
                // kiểm tra xem sinh viên với mã vừa nhập có trong danh sách chưa
                // nếu có rồi thì bỏ qua, nếu chưa thì cho tạo mới thông tin
                var indexOfStudent = FindStudentIndexById(students, studentId);
                if (indexOfStudent >= 0)
                {
                    Console.WriteLine($"==> Sinh viên mã \"{studentId}\" đã tồn tại.");
                    return null;
                }
            }
            Console.WriteLine("Họ và tên: ");
            var name = Console.ReadLine().Trim();
            if (!filter.IsNameValid(name))
            {
                var msg = "Họ và tên không hợp lệ.";
                throw new InvalidNameException(msg, name);
            }
            Console.WriteLine("Ngày sinh dạng 01/01/2001: ");
            var birthDate = Console.ReadLine().Trim();
            if (!filter.IsBirthDateValid(birthDate))
            {
                var msg = "Ngày sinh không hợp lệ.";
                throw new InvalidBirthDateException(msg, birthDate);
            }
            var dateFormat = "dd/MM/yyyy";
            DateTime dob = DateTime.ParseExact(birthDate, dateFormat, null);

            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            if (!filter.IsEmailValid(email))
            {
                var msg = "Email không hợp lệ.";
                throw new InvalidEmailException(msg, email);
            }
            Console.WriteLine("Số điện thoại: ");
            var phoneNumber = Console.ReadLine();
            if (!filter.IsPhoneValid(phoneNumber))
            {
                var msg = "Số điện thoại không hợp lệ.";
                throw new InvalidPhoneNumberException(msg, phoneNumber);
            }
            Console.WriteLine("Chuyên ngành: ");
            var major = Console.ReadLine();
            return new Student(studentId, name, dob, email, phoneNumber, major);
        }

        // tìm sinh viên/môn học theo tên
        internal List<T> FindByName<T>(List<T> data, string name)
        {
            List<T> result = new List<T>();
            var pattern = $".*{name}.*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (typeof(T) == typeof(Student))
            {
                foreach (var item in data)
                {
                    var student = item as Student;
                    if (regex.IsMatch(student.FullName.FirstName))
                    {
                        result.Add(item);
                    }
                }
            }
            else if (typeof(T) == typeof(Subject))
            {
                foreach (var item in data)
                {
                    var subject = item as Subject;
                    if (regex.IsMatch(subject.Name))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        // phương thức generic hiển thị danh sách sinh viên, môn học, đăng ký
        public void ShowData<T>(List<T> data)
        {
            var type = typeof(T);
            if (type == typeof(Student))
            {
                var students = data as List<Student>;
                ShowStudents(students);
            }
            else if (type == typeof(Subject))
            {
                var subjects = data as List<Subject>;
                ShowSubjects(subjects);
            }
            else if (type == typeof(Register))
            {
                var registers = data as List<Register>;
                ShowRegisters(registers);
            }
        }

        // hiển thị danh sách sinh viên
        public void ShowStudents(List<Student> students)
        {
            var dateFormat = "dd/MM/yyyy";
            var id = "Mã sinh viên";
            var birthDate = "Ngày sinh";
            var email = "Email";
            var phoneNumber = "Số điện thoại";
            var name = "Họ và tên";
            var major = "Chuyên ngành";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{birthDate,-15:d}" +
                $"{email,-30:d}{phoneNumber,-15:d}{major,-15:d}");
            foreach (var student in students)
            {
                if (student == null)
                {
                    continue;
                }
                Console.WriteLine($"{student.StudentId,-15:d}{student.FullName,-25:d}" +
                    $"{student.BirthDate.ToString(dateFormat),-15:d}{student.Email,-30:d}" +
                    $"{student.PhoneNumber,-15:d}{student.Major,-15:d}");
            }
        }

        // hiển thị danh sách đăng ký
        public void ShowRegisters(List<Register> registers)
        {
            var id = "Mã đăng ký";
            var stId = "Mã sinh viên";
            var stName = "Tên sinh viên";
            var suId = "Mã môn học";
            var suName = "Tên môn học";
            var regTime = "Thời gian đăng ký";
            Console.WriteLine($"{id,-15:d}{stId,-15:d}{stName,-25:d}{suId,-15:d}{suName,-25:d}{regTime,-15:d}");
            foreach (var reg in registers)
            {
                if (reg == null)
                {
                    continue;
                }
                Console.WriteLine($"{reg.RegisterId,-15:d}{reg.Student.StudentId,-15:d}" +
                    $"{reg.Student.FullName,-25:d}{reg.Subject.SubjectId,-15:d}" +
                    $"{reg.Subject.Name,-25:d}{reg.RegisterTime.ToString("dd/MM/yyyy HH:mm:ss"),-15:d}");
            }
        }

        // hiển thị danh sách môn học
        public void ShowSubjects(List<Subject> subjects)
        {
            var id = "Mã môn học";
            var name = "Tên môn học";
            var credit = "Số tín chỉ";
            var lesson = "Số tiết học";
            Console.WriteLine($"{id,-15:d}{name,-25:d}{credit,-15:d}{lesson,-15:d}");
            foreach (var subject in subjects)
            {
                if (subject == null)
                {
                    continue;
                }
                Console.WriteLine($"{subject.SubjectId,-15:d}{subject.Name,-25:d}" +
                    $"{subject.Credit,-15:d}{subject.NumOfLesson,-15:d}");
            }
        }

        // sắp xếp danh sách sinh viên theo tên, nếu trùng tên thì sắp xếp theo họ a-z
        public void Sort<T>(List<T> data)
        {
            data.Sort();
        }

        // sắp xếp danh sách đăng ký theo mã sinh viên
        public void SortBy<T>(List<T> registers, IComparer<T> comparer)
        {
            registers.Sort(comparer);
        }

        // tìm bản đăng ký theo mã sinh viên
        public List<Register> FindRegisterByStudentId(List<Register> registers)
        {
            var result = new List<Register>();
            Console.WriteLine("Mã sinh viên cần tìm: ");
            var studentId = Console.ReadLine().ToUpper();
            if (!filter.IsStudentIdValid(studentId))
            {
                var msg = "Mã sinh viên không hợp lệ";
                throw new InvalidStudentIdException(msg, studentId);
            }
            foreach (var item in registers)
            {
                if (item == null)
                {
                    break;
                }
                if (item.Student.StudentId.CompareTo(studentId) == 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // cập nhật số tiết học của một môn học
        public void UpdateSubjectLesson(List<Subject> subjects)
        {
            Console.WriteLine("Nhập mã môn học: ");
            var sjIdString = Console.ReadLine();
            if (!filter.IsSubjectIdValid(sjIdString))
            {
                throw new InvalidSubjectIdException("Mã môn học không hợp lệ.", sjIdString);
            }
            var subjectId = int.Parse(sjIdString);
            var subjectIndex = FindSubjectIndexById(subjects, subjectId);
            if (subjectIndex == -1)
            {
                Console.WriteLine("==> Không tồn tại môn học cần cập nhật. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn cập nhật?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    Console.WriteLine("Số tiết học: ");
                    var lesson = int.Parse(Console.ReadLine());
                    subjects[subjectIndex].NumOfLesson = lesson;
                    Console.WriteLine("==> Cập nhật thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Cập nhật bị hủy. <==");
                }
            }
        }

        // cập nhật thông tin sinh viên khi biết mã sinh viên
        public void UpdateStudentInfo(List<Student> students)
        {
            Console.WriteLine("Nhập mã sinh viên: ");
            var studentId = Console.ReadLine().ToUpper(); // viết hoa mã sinh viên
            if (!filter.IsStudentIdValid(studentId))
            {
                var message = "Mã sinh viên không hợp lệ";
                throw new InvalidStudentIdException(message, studentId);
            }
            var index = FindStudentIndexById(students, studentId);
            if (index == -1)
            {
                Console.WriteLine("==> Không tồn tại sinh viên cần cập nhật. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn cập nhật?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    Console.WriteLine("Họ và tên: ");
                    var name = Console.ReadLine();
                    if (!filter.IsNameValid(name))
                    {
                        throw new InvalidNameException("Họ và tên không hợp lệ.", name);
                    }
                    students[index].FullName = new FullName(name);
                    Console.WriteLine("==> Cập nhật thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Cập nhật bị hủy. <==");
                }
            }
        }

        internal List<Student> MostRegistedStudent(List<Register> registers)
        {
            int maxRegisted = 0;
            List<Pair<Student, int>> pairs = new List<Pair<Student, int>>();
            // xét từng môn học
            for (int i = 0; i < registers.Count; i++)
            {
                // nếu môn học đang xét chưa được xem xét trước đó
                if (!IsStudentExisted(registers, registers[i].Student, i))
                {
                    // tìm số lần xuất hiện của môn học này trong danh sách đăng ký
                    var counter = CountRegisterOfStudent(registers, registers[i].Student);
                    pairs.Add(new Pair<Student, int>(registers[i].Student, counter));
                    if (counter > maxRegisted)
                    {
                        maxRegisted = counter;
                    }
                }
            }
            // tiếp theo, tìm môn học được đăng ký nhiều nhất
            List<Student> result = new List<Student>();
            foreach (var pair in pairs)
            {
                if (pair.Value == maxRegisted)
                {
                    result.Add(pair.Key);
                }
            }
            return result;
        }

        // tìm các sinh viên đăng ký sớm nhất
        internal List<Student> EarliestRegistedStudent(List<Register> registers)
        {
            List<Student> students = new List<Student>();
            DateTime earliestTime = FindEarliest(registers);
            foreach (var item in registers)
            {
                if (item.RegisterTime == earliestTime)
                {
                    students.Add(item.Student);
                }
            }
            return students;
        }

        private DateTime FindEarliest(List<Register> registers)
        {
            DateTime t = registers[0].RegisterTime;
            foreach (var item in registers)
            {
                if (item.RegisterTime < t)
                {
                    t = item.RegisterTime;
                }
            }
            return t;
        }

        // đếm số lần xuất hiện của 1 sinh viên trong bảng đăng ký
        private int CountRegisterOfStudent(List<Register> registers, Student student)
        {
            int counter = 0;
            foreach (var item in registers)
            {
                if (item.Student.StudentId.CompareTo(student.StudentId) == 0)
                {
                    counter++; // nếu tìm thấy thì tăng biến đếm số lần xuất hiện của sv đó lên
                }
            }
            return counter; // trả về kết quả số lần xuất hiện
        }

        // tìm các sinh viên đăng ký muộn nhất
        internal List<Student> LatestRegistedStudent(List<Register> registers)
        {
            List<Student> students = new List<Student>();
            DateTime lastestTime = FindLatest(registers);
            foreach (var item in registers)
            {
                if (item.RegisterTime == lastestTime)
                {
                    students.Add(item.Student);
                }
            }
            return students;
        }

        private DateTime FindLatest(List<Register> registers)
        {
            DateTime t = registers[0].RegisterTime;
            foreach (var item in registers)
            {
                if (item.RegisterTime > t)
                {
                    t = item.RegisterTime;
                }
            }
            return t;
        }

        // phương thức kiểm tra xem sinh viên cho trước đã tồn tại trước vị trí pos chưa
        private bool IsStudentExisted(List<Register> registers, Student student, int pos)
        {
            for (int i = 0; i < pos; i++)
            {
                if (registers[i].Student.StudentId.CompareTo(student.StudentId) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        internal List<Subject> MostRegistedSubject(List<Register> registers)
        {
            int maxRegisted = 0;
            List<Pair<Subject, int>> pairs = new List<Pair<Subject, int>>();
            // xét từng môn học
            for (int i = 0; i < registers.Count; i++)
            {
                // nếu môn học đang xét chưa được xem xét trước đó
                if (!IsExisted(registers, registers[i].Subject, i))
                {
                    // tìm số lần xuất hiện của môn học này trong danh sách đăng ký
                    var counter = CountRegisterOfSubject(registers, registers[i].Subject);
                    pairs.Add(new Pair<Subject, int>(registers[i].Subject, counter));
                    if (counter > maxRegisted)
                    {
                        maxRegisted = counter;
                    }
                }
            }
            // tiếp theo, tìm môn học được đăng ký nhiều nhất
            List<Subject> result = new List<Subject>();
            foreach (var pair in pairs)
            {
                if (pair.Value == maxRegisted)
                {
                    result.Add(pair.Key);
                }
            }
            return result;
        }

        private int CountRegisterOfSubject(List<Register> registers, Subject subject)
        {
            int counter = 0;
            foreach (var item in registers)
            {
                if (item.Subject.SubjectId == subject.SubjectId)
                {
                    counter++; // nếu tìm thấy thì tăng biến đếm số lần xuất hiện của môn học đó lên
                }
            }
            return counter; // trả về kết quả số lần xuất hiện
        }

        // phương thức kiểm tra một môn học đã xuất hiện trước vị trí pos chưa
        private bool IsExisted(List<Register> registers, Subject subject, int pos)
        {
            for (int i = 0; i < pos; i++)
            {
                if (registers[i].Subject.SubjectId == subject.SubjectId)
                {
                    return true; // môn học đang xét đã tồn tại trước vị trí pos
                }
            }
            return false;
        }

        // xóa môn học theo mã cho trước
        public void RemoveSubject(List<Subject> subjects)
        {
            Console.WriteLine("Nhập mã môn học cần xóa: ");
            var subjectId = Console.ReadLine();
            if (!filter.IsSubjectIdValid(subjectId))
            {
                throw new InvalidSubjectIdException("Mã môn học không hợp lệ.", subjectId);
            }
            var idToRemove = int.Parse(subjectId);
            int index = FindSubjectIndexById(subjects, idToRemove);
            if (index == -1)
            {
                Console.WriteLine("==> Không tìm thấy môn học cần xóa. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    subjects.RemoveAt(index);
                    Console.WriteLine($"==> Môn học mã \"{idToRemove}\" đã được xóa khỏi danh sách. <==");
                }
                else
                {
                    Console.WriteLine("==> Hành động xóa môn học bị hủy bỏ. <==");
                }
            }
        }

        // tìm vị trí của bản đăng ký trong mảng khi biết mã đăng ký
        public int FindSubjectIndexById(List<Subject> subjects, int id)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                if (subjects[i] != null && subjects[i].SubjectId == id)
                {
                    return i;
                }
            }
            return -1; // không tìm thấy
        }

        // xóa sinh viên theo mã cho trước
        public void RemoveStudent(List<Student> students)
        {
            Console.WriteLine("Nhập mã sinh viên cần xóa: ");
            var idToRemove = Console.ReadLine().ToUpper();
            if (!filter.IsStudentIdValid(idToRemove))
            {
                var message = "Mã sinh viên không hợp lệ";
                throw new InvalidStudentIdException(message, idToRemove);
            }
            int index = FindStudentIndexById(students, idToRemove);
            if (index == -1)
            {
                Console.WriteLine("==> Không tìm thấy sinh viên cần xóa. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    students.RemoveAt(index);
                    Console.WriteLine($"==> Sinh viên mã \"{idToRemove}\" đã được xóa khỏi danh sách. <==");
                }
                else
                {
                    Console.WriteLine("==> Hành động xóa sinh viên bị hủy bỏ. <==");
                }
            }
        }

        // tìm vị trí của sinh viên cần xóa trong mảng
        public int FindStudentIndexById(List<Student> students, string id)
        {
            var targetStudent = new Student(id);
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i] != null && students[i].Equals(targetStudent))
                {
                    return i; // tìm thấy
                }
            }
            return -1; // không tìm thấy
        }

        // xóa bản đăng ký theo mã đăng ký
        public void RemoveRegister(List<Register> registers)
        {
            Console.WriteLine("Nhập mã bản đăng ký cần xóa: ");
            var regId = Console.ReadLine();
            if (!filter.IsRegisterIdValid(regId))
            {
                var msg = "Mã đăng ký không hợp lệ.";
                throw new InvalidRegisterIdException(msg, regId);
            }
            var idToRemove = int.Parse(regId);
            int index = FindRegisterIndexById(registers, idToRemove);
            if (index == -1)
            {
                Console.WriteLine("==> Không tìm thấy bản đăng ký cần xóa. <==");
            }
            else
            {
                Console.WriteLine("==> Bạn có chắc chắn muốn xóa không?(Y/N) ");
                var ans = Console.ReadLine()[0];
                if (ans == 'Y' || ans == 'y')
                {
                    registers.RemoveAt(index);
                    Console.WriteLine($"==> Bản ghi mã \"{idToRemove}\" đã được xóa khỏi danh sách. <==");
                }
                else
                {
                    Console.WriteLine("==> Hành động xóa bản đăng ký bị hủy bỏ. <==");
                }
            }
        }

        // tìm vị trí của bản đăng ký trong mảng khi biết mã đăng ký
        public int FindRegisterIndexById(List<Register> registers, int id)
        {
            for (int i = 0; i < registers.Count; i++)
            {
                if (registers[i] != null && registers[i].RegisterId == id)
                {
                    return i;
                }
            }
            return -1; // không tìm thấy
        }
    }
}
