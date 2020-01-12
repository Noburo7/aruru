using System.Collections.Generic;

namespace Aruru.Course
{
    public class Chukyo : ICourse
    {
        public string Name { get; } = "中京";
        public string ID { get; } = "CK";

        public List<int> GrassCourse() {
            var list = new List<int> {
                1200, 1400, 1600, 2000, 2200
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1200, 1400, 1800, 1900
            };
            return list;
        }
    }
}
