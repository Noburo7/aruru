using System.Collections.Generic;

namespace Aruru.Course
{
    public class Fukushima : ICourse
    {
        public string Name { get; set; } = "福島";
        public string ID { get; set; } = "FK";

        public List<int> GrassCourse() {
            var list = new List<int> {
                1200, 1800, 2000, 2600
            };

            return list;
        }

        public List<int> DirtCourse() {
            var list = new List<int> {
                1150, 1700, 2400
            };
            return list;
        }
    }
}
