Certainly! Here is a README file for the above methods:

# CommonExtensions

This class contains commonly used extension methods for general purposes.

## Methods

### `Assigned`

```csharp
public static bool Assigned(this string value)
```

This method checks if a string variable has been assigned a value.

#### Parameters

- `value` (string): The string variable to check.

#### Return Value

`bool`: Returns `true` if the variable has been assigned a value, otherwise `false`.

---

### `IsNumeric`

```csharp
public static bool IsNumeric(this string value)
```

This method determines whether a string represents a numeric value.

#### Parameters

- `value` (string): The string to check.

#### Return Value

`bool`: Returns `true` if the string can be parsed as a number, such as an integer or a decimal value, otherwise `false`.

---

### `ToInt`

```csharp
public static int ToInt(this string value)
```

This method converts a string representing a number to an integer.

#### Parameters

- `value` (string): The string to convert.

#### Return Value

`int`: The integer value parsed from the string.

---

### `ToIntOrDefault`

```csharp
public static int ToIntOrDefault(this string value, int defaultValue)
```

This method converts a string representing a number to an integer. If the string cannot be parsed, it returns the specified `defaultValue` instead of throwing an exception.

#### Parameters

- `value` (string): The string to convert.
- `defaultValue` (int): The default value to return if the string cannot be parsed.

#### Return Value

`int`: The integer value parsed from the string, or the `defaultValue` if the string cannot be parsed.

---

### `ToDouble`

```csharp
public static double ToDouble(this string value)
```

This method converts a string representing a number to a double.

#### Parameters

- `value` (string): The string to convert.

#### Return Value

`double`: The double value parsed from the string.

---

### `ToDoubleOrDefault`

```csharp
public static double ToDoubleOrDefault(this string value, double defaultValue)
```

This method converts a string representing a number to a double. If the string cannot be parsed, it returns the specified `defaultValue` instead of throwing an exception.

#### Parameters

- `value` (string): The string to convert.
- `defaultValue` (double): The default value to return if the string cannot be parsed.

#### Return Value

`double`: The double value parsed from the string, or the `defaultValue` if the string cannot be parsed.

---

# Common Extensions

This is a collection of common extensions for various data types and classes in C#.

## Table of Contents
- [String Extensions](#string-extensions)
- [DateTime Extensions](#datetime-extensions)
- [Double Extensions](#double-extensions)
- [Object Extensions](#object-extensions)
- [Type Extensions](#type-extensions)
- [Array Extensions](#array-extensions)
- [Stream Extensions](#stream-extensions)
- [Dictionary Extensions](#dictionary-extensions)
- [IEnumerable Extensions](#ienumerable-extensions)
- [String Manipulation Extensions](#string-manipulation-extensions)
- [Type Checking Extensions](#type-checking-extensions)
- [Other Extensions](#other-extensions)

## String Extensions

- `Assigned()`: Checks if the string is not null or empty.
- `NotAssigned()`: Checks if the string is null or empty.
- `RegexReplace(string pattern, string replacement)`: Performs a regular expression replacement on the string.

## DateTime Extensions

- `Assigned()`: Checks if the DateTime object is assigned (greater than DateTime.MinValue).
- `NotAssigned()`: Checks if the DateTime object is not assigned (equal to DateTime.MinValue).
- `OnlyDate()`: Returns a new DateTime object with the time portion set to midnight.

## Double Extensions

- `Assigned()`: Checks if the double value is not NaN.
- `NotAssigned()`: Checks if the double value is NaN.
- `ToVal()`: Converts a nullable double value to a double, returning the default value if null.

## Object Extensions

- `Assigned()`: Checks if the object is not null or DBNull.
- `NotAssigned()`: Checks if the object is null or DBNull.
- `RootNamespace()`: Retrieves the root namespace of the assembly containing the object.

## Type Extensions

- `ToType()`: Returns the underlying type of a nullable type, or the original type if not nullable.
- `IsBaseType(Type parent, Type child)`: Checks if the child type is a derived type of the parent type.

## Array Extensions

- `ValidArray()`: Checks if the array is assigned and has a length greater than zero.

## Stream Extensions

- `StreamToByteArray()`: Converts a stream to a byte array.
- `ToMemoryStream()`: Creates a new memory stream from a byte array.
- `StreamToStr()`: Converts the contents of a memory stream to a base64-encoded string.
- `StrToStream()`: Initializes a memory stream from a base64-encoded string.
- `Clone<T>(Stream input)`: Creates a binary copy of a stream.

## Dictionary Extensions

- `Value<TKey, TValue>(IDictionary<TKey, TValue> list, TKey key)`: Gets the value associated with the specified key.

## IEnumerable Extensions

- `ToNewList<T>(this IList list)`: Creates a new List<T> from an IList object.
- `ToNewList<T>(this IEnumerator enumerator)`: Creates a new List<T> from an IEnumerator object.
- `ToNewList(this IEnumerator enumerator)`: Creates a new ArrayList from an IEnumerator object.

## String Manipulation Extensions

- `IncrementLastChar()`: Increments the last character of a string.
- `AsciiEncodeToBase64()`: Encodes a string to a base64-encoded ASCII string.
- `AsciiDecodeFromBase64()`: Decodes a base64-encoded ASCII string to a string.
- `ReverseString()`: Reverses the characters in a string.

## Type Checking Extensions

- `IsAlphaNumeric()`: Checks if a type is a char or string.
- `IsPrimitiveNumericOrString.

