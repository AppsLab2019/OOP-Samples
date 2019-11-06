# Vehicle Service Inheritance Sample

This simplified OOP (Object-Oriented-Programming) sample shows the principle of inheritence. Let's create a simple service for all kind of vehicles, for example cars and buses.

So we would have two classes representing these two types of vehicles we are able to repair in our service. First class `Car` would look like this:

```csharp
class Car
{
    public Car(int consumption)
    {
        this.NumberOfWheels = 4;
        this.Weight = weight;
        this.Consumption = consumption;
    }

    public int NumberOfWheels { get; }
    public int Consumption { get; }
    public double ActualFuelCapacity { get; private set; }

    public void UpdateCarActualFuelCapacity(double distancePassed)
    {
        this.ActualFuelCapacity -= distancePassed / this.Consumption;
    }

}
```

The second class representing a bus objects would look like this:

---

```csharp
class Bus
{
    private IList stopList;

    public Bus(int consumption)
    {
        this.NumberOfWheels = 6;
        this.Weight = weight;
        this.Consumption = consumption;
    }

    public int NumberOfWheels { get; }
    public int Consumption { get; }
    public double ActualFuelCapacity { get; private set; }

    public void AddStop(...) { ... }
    public void RemoveStop(...) { ... }

    public void UpdateBusActualFuelCapacity(double distancePassed)
    {
        this.ActualFuelCapacity -= distancePassed / this.Consumption;
    }
}
```

We can notice that both classes although they represent seperate type of objects they have something in common. They both store information about what the number of wheels, consumption and  actual fuel capacity are because for both – buses and cars – it’s relevant to know these properties.

Then they also have something that is specific just for them - like buses can have some list of stops and there can be some stop added or removed from that list using methods set for use for this functionality.

Let’s ignore some other properties and method definitions. This example is just to demonstrate the meaning and benefits of inheritance principle.

If we code it this way some parts of code in both classes is the same. In addition if we wanted to extend services to repair different kinds of vehicles we would still have to create more and more classes that would have just the same parts of code.

## Inheritance OOP principle

Here comes principle of inheritance just in hand. When we use inheritance, we create a class that will contain properties and methods that are common for certain group of objects. Bus, car, motorbike, van.. these are all vehicles and they all have something in common like we have seen before. So let’s create a class `Vehicle` and put there a code that is relevant for all kinds of vehicles. The class `Vehicle` could liked this:


```csharp
class Vehicle
{
    public Vehicle(int numberOfWheels, int consumption)
    {
        this.NumberOfWheels = numberOfWheels;
        this.Consumption = consumption;
    }

    public int NumberOfWheels { get; }
    public int Consumption { get; }
    public double ActualFuelCapacity { get; private set; }

    public void UpdateActualFuelCapacity(double distancePassed)
    {
        this.ActualFuelCapacity -= distancePassed / this.Consumption;
    } 

    public string ToString()
    {
        return "This is a vehicle.";
    }
}
```
---

We all know these code from previous classes. There is just one difference that we added `numberOfWheels` parameter to constructor so now we can specify how many wheels will vehicle have in a moment of its creation. About all kind vehicles we can say that they have some wheels, some consumption and actual fuel capacity that can be updated via `UpdateActualFuelCapacity` method we have also adjusted the name of the method to be more general, so we don’t have UpdateBusActualFuelCapacity and UpdateCarActualFuelCapacity but only UpdateActualFuelCapacity).

Ok! Now we have our class that we can create a Vehicles from. But remember our classes from the beginning – `Bus` and `Car`. And remember that bus has its own unique properties and methods that only buses need. We will adjust our class `Bus` to have its own properties and methods but also to have a common vehicle properties and methods – because bus is a vehicle. So `Bus` will inherit properties and methods of `Vehicle`. We call this relation as parent – child relation (parent class in C# is also called base class).

Just like in real life. We are kids of our father and mother and we did inherit something from them, for example the name – and that makes us all to be from one family with the same name property.

So let’s change the Bus class to look like this:

```csharp
public Book FindByName(string name)
{
    foreach (var book in books)
    {
        if (book.Name == name)
        {
            return book;
        }
    }
    return null;
}
```

---

Let's add method to `Library` class to find book by `author`:

```csharp
class Bus : Vehicle
{
    private IList stopList;

    public Bus(int consumption) : base(6, consumption)
    {
        this.Consumption = consumption;
    }

    public void AddStop() { }
    public void RemoveStop() { }

}
```

See that all these methods could return found `book` object or `null` when book is not found.
`null` is a special keyword in C# that basically says that there is **no object**.

Let's continue.

---
If we have a `Book` object found we need to check if this book is available and it can be borrowed.
Let's add new `bool` property to `Book` class that will informs about available state. Like this:

```csharp
class Book
{
    public Book(int id, string name, string author)
    {
        Name = name;
        Author = author;
    }

    public int Id { get; }
    public string Name { get; }
    public string Author { get; }
    public bool IsAvailable { get; set; }
}
```

In C# we use `:` operator to make a class inherit from some other class. So here Class `Bus : Vehicle` means that class `Bus` inherits from class `Vehicle`. Notice that we can use `this.Consumption` although it’s not directly defined in class `Bus` but is inherited from the parent class thus it’s no problem to use it in child class. Same way we could use method `UpdateActualFuelCapacity` in any `Bus` objects or `Car` objects. It’s also inherited so every child has it as it is public. Private fields and methods are not inherited. Here comes also protected keywork into consideration. When something has `protected` access modifier used it is visible to all child classes but remains invisible for non-child classes.

Don’t miss also a keyword `base` which allows us to directly ask parent (`base`) class for any property or method to invoke.
We can do just the same with `Car` class.

But what will happen to the types of these objects? Will a created instance be a `Bus` or `Vehicle` then? The answer is both. Let’s find a proof for this. Let’s try to create two vehicles – 1 car and 1 bus. Thanks to inheritance we implemented we can do it like this:

```csharp
static void Main(string[] args)
{
    Vehicle v1 = new Bus(8);
    Vehicle v2 = new Car(6);

    Console.WriteLine(v1.ToString());
    Console.WriteLine(v2.ToString());
}
```

Thanks to inheritance this is not a problem. We could also have a list of vehicles (`List<Vehicle>`) defined and we could put there all cars and buses and we wouldn’t need to have separate lists for both types because they are both vehicles so they perfectly fit to list of vehicles. If we run this code we’ll get the output:

This is a vehicle.
This is a vehicle.

They both are vehicles and since we have not yet defined a specific `ToString()` method for `Car` nor for `Bus`, `base` class `ToString()` is used. What if wanted to have “This is a car.” at the output when vehicle is a car, and “This is a bus.” when it’s a bus?

We could achieve this by having ToString() method defined solo for Car class and solo for Bus class. Let’s add these methods to our classes and see what we get.

```csharp
public Car(int consumption) : base (4, consumption)
{
    this.Consumption = consumption;
}

public string ToString()
{
    return "This is car.";
}
```

We do the same in `Bus` class – we add following method to `Bus` class:

---

```csharp
public string ToString()
{
    return "This is bus.";
}

```
Let’s what we’ll get when we run the code again:

This is a vehicle.
This is a vehicle.

---

Nothing has changed with the output. That’s because we forgot something. Method in base and child class has the same name (`ToString()`) and C# will execute the base method since we specified type as Vehicle when we were creating our objects. If we want to have `ToString()` method working as we desire here, we need to add `override` keyword to method declaration in child classes:

```csharp
public override string ToString()
{
    return "This is a vehicle.";
}
```

`override` keyword will tell C# that we want to override parent’s method and that we want to use our own instead. We also need to use this keyword at `ToString()` method in base class to say that this method can be overridden. Let’s do it and see what we get now:
---

This is a bus.
This is a car.

Looks better now.


## `is` keyword

In C# there is a is keyword which allows us to ask for type of object that was originally created from. As we used `new Bus(8)` and `new Car(6)` constructors, v1 should be a `Bus` and v2 should be a `Car`. So if had a list of vehicles and wanted to go through the list and do specific task with cars and something else with buses, we could just use a conditional to ask for the type of object and what we want. Like this:

```csharp
static void Main(string[] args)
{
    Vehicle v1 = new Bus(8);
    Vehicle v2 = new Car(6);

    List<Vehicle> vehicles = new List<Vehicle>();
    vehicles.Add(v1);
    vehicles.Add(v2);

    foreach (Vehicle v in vehicles)
    {
        if (v is Car)
        {
            Console.WriteLine("This is a car.");
        }
        else if (v is Bus)
        {
            Console.WriteLine("This is a bus.");
        }
        else
        {
            Console.WriteLine("Unknown type of vehicle.");
        }
    }
}
```
