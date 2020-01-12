using System.Collections.Generic;

namespace Aruru.Course
{
    public class Nigata : ICourse
    {
        public string Name { get; } = "新潟";
        public string ID { get; } = "NG";

        public List<int> GrassCourse() {
            var list = new List<int> {
                1000, 1200, 1400, 1600, 1800, 2000, 2200, 2400
            };
            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1200, 1800
            };
            return list;
        }
    }
}
