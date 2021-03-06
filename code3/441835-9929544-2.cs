    public class Division
    {
        public int ID { get; set; }
        public int DivisionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private static List<Division> _divisions;
        public static List<Division> Divisions
        {
            get
            {
                if (_divisions == null) {
                    LoadAndSetUpDivisions();
                }
                return _divisions;
            }
        }
        private static Dictionary<int, Division> _divisionsByID;
        public static Dictionary<int, Division> DivisionsByID
        {
            get
            {
                if (_divisionsByID == null) {
                    LoadAndSetUpDivisions();
                }
                return _divisionsByID;
            }
        }
        private static Division _root;
        public static Division Root
        {
            get
            {
                if (_root == null) {
                    LoadAndSetUpDivisions();
                }
                return _root;
            }
        }
        private Division _parentDivision;
        public Division ParentDivision
        {
            get
            {
                if (_parentDivision == null && DivisionID != null) {
                    _parentDivision = DivisionsByID[DivisionID];
                }
                return _parentDivision;
            }
        }
        private List<Division> _subDivisions = new List<Division>();
        public List<Division> SubDivisions
        {
            get { return _subDivisions; }
        }
        private static void LoadAndSetUpDivisions()
        {
            // Load the divisions in a non-recursive way using LINQ
            // (details not shown here).
            _divisions = LoadDivisions();
            // Add the divisions in a dictionary by id
            _divisionsByID = new Dictionary<int, Division>(_divisions.Count);
            foreach (Division division in _divisions) {
                _divisionsByID.Add(division.ID, division);
            }
            // Define sub-divisions and root division
            foreach (Division division in _divisions) {
                if (division.DivisionID == null) {
                    _root = division;
                } else if (division.ParentDivision != null) {
                    division.ParentDivision.SubDivisions.Add(division);
                }
            }
        }
        private static List<Division> LoadDivisions()
        {
            throw new NotImplementedException();
        }
    }
