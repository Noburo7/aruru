using System.Collections.Generic;

namespace Aruru.Course
{
    public class TokyoCourse : ICourse
    {
        public string Name { get; } = "東京";
        public string ID { get; } = "TK";
        
        public List<int> GrassCourse() {
            var list = new List<int> {
                1300, 1400, 1600, 1800, 2000, 2300, 2400, 2500, 3400
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1300, 1400, 1600, 2100
            };
            return list;
        }
    }
}
