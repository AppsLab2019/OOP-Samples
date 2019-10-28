# Animals OOP Sample

Imagine that you want to create a **ZOO** game with many different animals. Players will have to take care of these animals, feed them, etc.

![Animals](https://media.istockphoto.com/vectors/funny-animals-vector-id505163508?k=6&m=505163508&s=612x612&w=0&h=F9mEEAEvTRwojhTA1DCIEGqETBWWOIn1El4xJnpXOwE=)

There can be different animals like e.g.:
* lion
* panda
* giraffe
* zebra
* elephant
* bird
* monkey
* etc...

Let's think about it and start implementing some functionality.
We will create a class with name `Animal` that will represent every type of animal.

```csharp
class Animal
{
}
```

Each animal can have a name and this name cannot be changed, once animal is created.

```csharp
class Animal
{
    public Animal(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
```

It is also important to know what type of animal it is, and this is also not changed once this animal is created.

```csharp
class Animal
{
    public Animal(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }
    public string Type { get; }
}
```

Let's consider that each animal has some health, which we can represent by property `HealthPoints`. This property can be changed once this object is created, but it needs to be set when animal is created. Something like this:

```csharp
class Animal
{
    public Animal(string name, string type, int healthPoints)
    {
        Name = name;
        Type = type;
        HealthPoints = healthPoints;
    }

    public string Name { get; }
    public string Type { get; }
    public int HealthPoints { get; set; }
}
```

Let's consider that animal can have a status of `Food` and it also can change over time. 

```csharp
class Animal
{
    public Animal(string name, string type, int healthPoints, int food)
    {
        Name = name;
        Type = type;
        HealthPoints = healthPoints;
        Food = food;
    }

    public string Name { get; }
    public string Type { get; }
    public int HealthPoints { get; set; }
    public int Food { get; set; }
}
```

* If animal has no food, it's health will decrease over time. 
* It's food should be decreased when animal is "updated" (e.g. every hour). 
* Food could not be negative.
* If `HealthPoints` are zero, animal starves to death.
* `HealthPoints` could not be negative.

Let's add `Update()` method to `Animal` class.
```csharp
public void Update()
{
    if (HealthPoints <= 0) return;
    Food--;
    if (Food <= 0)
    {
        HealthPoints--;
        if (HealthPoints > 0)
        {
            Console.WriteLine($"{Name} is starving.");
        }
        else
        {
            Console.WriteLine($"{Name} starved to death.");
            HealthPoints = 0;
        }
        Food = 0;
    }
}
```

Now, when animals can starve, they also should be able to eat. Let's implement that:

Let's add method `Eat(int amount)` which will increase animal's food status.

```csharp
public void Eat(int amount)
{
    Food += amount;
}
```

We need some system that will create animals and "update" them over time. Let's implement class `Zoo` that will do that.

```csharp
class Zoo
{
}
```

Let's create some animals in contructor of `Zoo` class.

```csharp
class Zoo
{
    private readonly List<Animal> animals;

    public Zoo()
    {
        animals = new List<Animal>
        {
            new Animal("Lion", "Mammal", 200, 7),
            new Animal("Bear", "Mammal", 300, 10),
            new Animal("Cat", "Mammal", 50, 5),
            new Animal("Fish", "Aquarium", 10, 3),
        };
    }
}
```

Let's create method `Update()` which will call method `Update()` of each animal:

```csharp
public void Update()
{
    foreach (var animal in animals)
    {
        animal.Update();
    }
}
```

Let's add method `Feed(string name, int amount)` which will feed specified animal by it's name and helper private method for finding animal by name.

```csharp
public void Feed(string name, int amount)
{
    Animal animal = FindAnimalBy(name);
    if (animal != null)
    {
        animal.Eat(amount);
    }
}

private Animal FindAnimalBy(string name)
{
    foreach (var animal in animals)
    {
        if (animal.Name.ToLower() == name.ToLower())
        {
            return animal;
        }
    }

    return null;
}
```
Note, that additional method `FindAnimalBy(string name)` is `private` which means that it is visible only in this `Zoo` class.

Now, let's implement entry point of console application `Main` so that object `Zoo` is created and it's update and feed methods are called.

