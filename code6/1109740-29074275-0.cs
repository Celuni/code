    public class LectureTeacher
    {
        public string Lecture { get; set; }
        public string Teacher { get; set; }
    }
    
    public List<LectureTeacher> GetDogsWithBreedNames()
    {
        var res = classAttendanceByCriteria.OrderBy(x => x.Lecture.Id)
                                           .GroupBy(x => new { x.Lecture, x.Teacher })
                                           .Select(x => new LectureTeacher {Lecture  = x.Lecture.Key, Teacher  = x.teacher.Key})
                                           .ToList();
    
        return res;
    }
