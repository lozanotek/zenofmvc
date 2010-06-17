namespace Model {
    using System;

    [Serializable]
    public class Person {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        #region Equals Override

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof (Person)) {
                return false;
            }
            return Equals((Person) obj);
        }

        public bool Equals(Person obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return obj.Id == Id;
        }

        public override int GetHashCode() {
            unchecked {
                int result = 0;
                result = (result*397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                result = (result*397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                result = (result*397) ^ Birthdate.GetHashCode();
                return result;
            }
        }

        #endregion
    }
}
