# 📚 Design Patterns in Practice - C#

This document provides a catalog of design patterns in C#, explaining their purpose, advantages, and disadvantages. The patterns are grouped into the following categories:

- **Creational**
- **Structural**
- **Behavioral**

## 📖 Design Pattern Catalog

### 🔧 Creational Patterns
Creational patterns provide ways to instantiate objects while abstracting the instantiation process.

### 🟢 Singleton
Ensures that a class has only one instance and provides a global access point to that instance.

**Pros:**
- Ensures a single instance of a class is created.
- Provides a global access point to that instance.
- Lazy initialization — only created when first accessed.

**Cons:**
- Violates the **Single Responsibility Principle** by solving two problems at once (instance control and global access).
- Can hide poor design when components are overly dependent on each other.
- Requires special handling in multithreaded environments to avoid multiple instances.
- Difficult to mock and unit test due to the private constructor and static access.

### 🛠 Builder
Allows creating complex objects step by step, improving code readability.

**Pros:**
- Simplifies the creation of complex objects.
- Allows building different representations of an object using the same construction code.
- Follows the **Single Responsibility Principle** by separating the object construction logic from business logic.

**Cons:**
- Increases code complexity by requiring multiple new classes.
- May introduce unnecessary layers if the object construction is simple.

---

### 🏗 Structural Patterns
Structural patterns focus on the composition of objects, ensuring that interfaces and implementations work together effectively.

### 🔄 Adapter
Allows objects with incompatible interfaces to work together by creating a bridge between them.

**Pros:**
- Follows the **Single Responsibility Principle** by separating the interface adaptation logic from the main business logic.
- Adheres to the **Open/Closed Principle**, enabling the introduction of new adapters without modifying existing client code.

**Cons:**
- Increases code complexity by introducing additional interfaces and classes.
- In some cases, modifying the original service class may be simpler.

---

### 🧩 Behavioral Patterns
Behavioral patterns manage interactions and communications between objects, focusing on the division of responsibilities.

### 📋 Command
Encapsulates a request as an object, thereby allowing parameterization of clients with different requests, delayed execution, and undoable operations.

**Pros:**
- Follows the **Single Responsibility Principle** by decoupling the sender from the receiver.
- Adheres to the **Open/Closed Principle** by allowing new commands to be added without modifying existing code.
- Supports undo/redo functionality.
- Enables deferred execution of commands.

**Cons:**
- Increases code complexity by introducing a new layer between senders and receivers.

### 🕰 Memento
Captures and restores an object’s internal state without violating encapsulation.

**Pros:**
- Preserves encapsulation by not exposing an object’s internal state to other classes.
- Facilitates undo functionality without coupling the state management logic to the client.

**Cons:**
- Can increase memory usage when storing large or numerous states.
- The caretaker must manage the lifecycle of mementos carefully, which adds complexity.

---

### ⚙️ Structural/Behavioral Patterns
These patterns address both the composition and interaction of objects, managing data access and communication between them.

### 📂 Repository
Abstracts data access logic to centralize and encapsulate querying and persistence logic.

**Pros:**
- Separates business logic from data access logic, adhering to the **Single Responsibility Principle**.
- Provides a consistent API for data access, making it easier to switch data sources or models.
- Facilitates testing by allowing mock repositories to replace actual data sources.

**Cons:**
- May become overly complex if it tries to support too many use cases.
- Introduces additional layers of abstraction, which might not always be necessary.

## 📌 References
- [Refactoring Guru](https://refactoring.guru/design-patterns)  
- [DoFactory](https://www.dofactory.com/net/design-patterns)

