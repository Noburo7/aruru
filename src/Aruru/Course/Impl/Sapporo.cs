using System.Collections.Generic;

namespace Aruru.Course
{
    public class Sapporo : ICourse
    {
        public string Name { get; } = "札幌";
        public string ID { get; } = "SP";

        public List<int> GrassCourse() {
            var list = new List<int> {
                1000, 1200, 1500, 1800, 2000, 2600
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1000, 1700, 2400
            };
            return list;
        }
    }
}
