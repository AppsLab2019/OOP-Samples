# Sandbox OOP Sample

Imaging that you are on a sandbox and you want to play with some sand forms to create many different forms of creations.

![sandforms](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS9YRs94e35FXGraUe3DYdf2Gb_DaIhFgLSPjftOnRILQVArrq-yg&s)

There can be multiple different forms lying around in a sandbox, like e.g.:
* seahorse
* crab
* shell
* cake
* ice-cream
* etc...

Think about this forms as classes in C#. They represent a form of an object which can be used to create objects from sand.

Let's say we have class called `Seahorse` and we would like to use it to create our object from sand, we will use it's `constructor` and create new instance of an object `Seahorse`.

```csharp
class Seahorse
{
}
```

```csharp
Seahorse seahorse = new Seahorse();
```

* 1st `Seahorse` represents `type` of variable 
* 2nd `seahorse` is name of variable (lower case by naming convention)
* keyword `new` is used to call `constructor` of class `Seahorse`
* 3rd `Seahorse()` is constructor/class name (constructor has always same name as class).
* `Seahorse()` is constructor with no additional parameters

You can create multiple instances (objects) with same class e.g.:

```csharp
Seahorse seahorse1 = new Seahorse();
Seahorse seahorse2 = new Seahorse();
Seahorse seahorse3 = new Seahorse();
```

Same as you can create multiple sand objects with same sandform in sandbox playground.

As you have multiple forms in sandbox, you can have multiple classes in C#.

```csharp
class Cake
{
}

class IceCream
{
}
```

```csharp
Cake cake = new Cake();
IceCream iceCream = new IceCream();
```

Note, that you can also declare variable as implicit, using `var` keyword, like this:

```csharp
var cake = new Cake();
```
---
## TODO
1. Fork this repository
2. Open solution `Sandbox.sln`
3. Open Program.cs
4. Play with this solution by creating objects many different classes like `Seahorse`, `Crab`, `IceCream`, `Shell` or create your own class in `Main` method.
5. Commit&Sync your repository when you finish "playing".