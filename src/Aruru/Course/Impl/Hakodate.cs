using System.Collections.Generic;

namespace Aruru.Course
{
    public class Hakodate : ICourse
    {
        public string Name { get; } = "函館";
        public string ID { get; } = "HK";

        public List<int> GrassCourse() {
            var list = new List<int> {
                1000, 1200, 1800, 2000, 2600
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int>() {
                1000, 1700, 2400
            };
            return list;
        }
    }
}
