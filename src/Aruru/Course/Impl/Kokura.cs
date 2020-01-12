using System.Collections.Generic;

namespace Aruru.Course
{
    public class Kokura : ICourse
    {
        public string Name { get; } = "小倉";
        public string ID { get; } = "KR";

        public List<int> GrassCourse() {
            var list = new List<int> {
                1200, 1700, 1800, 2000, 2600
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
