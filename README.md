# CommonExtensions
Common Helper 

The CommonExtensions class is a collection of extension methods that provide additional functionality to existing types and objects. These methods are defined as static methods within the CommonExtensions class and can be called directly on the respective types.

Here is a brief description of each method in the CommonExtensions class:

*Assigned(this string source): Checks if a string is not null or empty.

*Assigned(this DateTime source): Checks if a DateTime object is assigned, i.e., it has a value greater than DateTime.MinValue.

*Assigned(this Double source): Checks if a double value is not NaN.

*Assigned(this object source): Checks if an object is assigned, i.e., it is not null or DBNull.Value.

*NotAssigned(this object source): Checks if an object is not assigned, i.e., it is null or DBNull.Value.

*RootNamespace(this Assembly source): Returns the root namespace of an assembly.

*ValidArray(this object[] o): Checks if an array is valid, i.e., assigned and has a length greater than zero.

*IsBaseType(this Type parent, Type child): Checks if a type is a base type of another type.

*ToType(this Type type): Returns the underlying type of a nullable type or the same type for non-nullable types.

*IncrementLastChar(this string word): Increments the last character of a string (e.g., "abc" becomes "abd").

*ToVal(this double? nullable): Converts a nullable double to a double value, using the nullable value if it has a value or the default value for double if it is null.

*ToVal(this short? nullable): Converts a nullable short to a short value, using the nullable value if it has a value or the default value for short if it is null.

*ToVal(this int? nullable): Converts a nullable integer to an integer value, using the nullable value if it has a value or the default value for int if it is null.

*ToVal(this DateTime? nullable): Converts a nullable DateTime to a DateTime value, using the nullable value if it has a value or a default value of January 1, 1753 if it is null.

*ToVal(this byte? nullable): Converts a nullable byte to a byte value, using the nullable value if it has a value or the default value for byte if it is null.

*ToVal(this char? nullable): Converts a nullable char to a char value, using the nullable value if it has a value or the default value for char if it is null.

*OnlyDate(this DateTime date): Returns a new DateTime object with the same year, month, and day values as the original DateTime but with zeroed time components.

*isInList(this object o, params object[] list): Checks if an object is in a given list of objects.

*ToUTF8ByteArray(this String source): Encodes a string as a byte array using UTF8 encoding.

*ToEncodedByteArray<T>(this String source): Encodes a string as a byte array using the specified encoding type.

*FromUTF8ByteArrayToStr(this Byte[] source): Decodes a byte array as a string using UTF8 encoding.

*FromEncodedByteArrayToStr<T>(this Byte[] source): Decodes a byte array as a string using the specified encoding type.

*AsciiEncodeToBase64(string s): Encodes a string in ASCII format to a Base64 string.

*AsciiDecodeFromBase64(string s): Decodes a Base64 string to an ASCII string.

*GetRealType(this Type genericType
