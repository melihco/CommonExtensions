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

Please let me know if there's anything else I can help you with!
