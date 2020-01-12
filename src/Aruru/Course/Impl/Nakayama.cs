using System.Collections.Generic;

namespace Aruru.Course
{
    public class Nakayama : ICourse
    {
        public string Name { get; } = "中山";
        public string ID { get; } = "NK";
        public List<int> GrassCourse() {
            var list = new List<int> {
                1200, 1600, 1800, 2000, 2200, 2500, 3600
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1200, 1800, 2400
            };
            return list;
        }
    }
}
