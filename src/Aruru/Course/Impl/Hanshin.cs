using System.Collections.Generic;

namespace Aruru.Course
{
    public class Hanshin : ICourse
    {
        public string Name { get; } = "阪神";
        public string ID { get; } = "HN";
        public List<int> GrassCourse() {
            var list = new List<int> {
                1200, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 3000
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1200, 1400, 1800, 2000
            };
            return list;
        }
    }
}
