# Design Patterns in Practice C#

- https://refactoring.guru/design-patterns
- https://www.dofactory.com/net/design-patterns  

## Design Pattern Catalog

- **_Creational_**: Provide ways to create objects and define how they will be instantiated.  
	- **Singleton**: Ensures a single instance of a class is created and shared across all resources.  
		- Pros:  
			- Ensures a class has only one instance.  
			- Provides a global access point to that instance.  
			- The singleton object is initialized only when requested for the first time.  
		- Cons:  
			- Violates the single responsibility principle. The pattern solves two problems at once.  
			- Can mask bad design, for instance, when program components know too much about each other.  
			- Requires special handling in a multithreaded environment to prevent multiple threads from creating multiple singleton objects.  
			- It can be challenging to perform unit testing on client code using Singleton because many testing frameworks rely on inheritance when producing mock objects. Since the singleton class constructor is private and overriding static methods is impossible in most languages, you will need a creative approach to mock the singleton. Or simply avoid testing it. Or don’t use the Singleton pattern.  

	- **Builder**: Allows constructing complex objects step by step.  
		- Pros:  
			- Can construct objects step by step, defer construction steps, or run steps recursively.  
			- Can reuse the same construction code for creating different representations of products.  
			- Single responsibility principle. You can isolate complex construction code from the business logic of the product.  
		- Cons:  
			- The overall code complexity increases because the pattern requires creating multiple new classes.  

- **_Structural_**: Deal with the composition of objects using inheritance and interfaces for various functionalities.  
	- **Adapter**: Makes objects with incompatible interfaces work together.  
		- Pros:  
			- Single responsibility principle. You can separate interface or data conversion from the primary business logic of the program.  
			- Open/closed principle. You can introduce new types of adapters into the program without breaking existing client code, as long as they work through the client interface.  
		- Cons:  
			- The overall code complexity increases because you need to introduce a set of new interfaces and classes. Sometimes it’s simpler to modify the service class to fit the rest of your code.  

- **_Behavioral_**: Focus on interactions and communication between objects, as well as the division of responsibilities.  
	- **Command**: Encapsulates a command request into an object.  
		- Pros:  
			- Single responsibility principle. You can decouple classes that invoke operations from those that perform these operations.  
			- Open/closed principle. You can introduce new commands into the application without breaking existing client code.  
			- Enables undo/redo functionality.  
			- Allows deferred execution of operations.  
			- Can assemble a set of simple commands into a complex one.  
		- Cons:  
			- The code may become more complex because you are introducing a new layer between senders and receivers.  

	- **Memento**: Captures and restores an object’s internal state without violating encapsulation.  
		- Pros:  
			- Ensures encapsulation by not exposing the implementation details of an object’s state.  
			- Facilitates undo functionality without coupling the object’s state-handling logic to the client.  
		- Cons:  
			- Can increase memory usage if many mementos are created or if the saved state is large.  
			- The caretaker must manage the lifecycle of mementos carefully, which adds complexity.  

- **_Structural/Behavioral_**: Patterns that can manage both data access and interaction between objects.  
	- **Repository**: Abstracts data access logic to centralize and encapsulate querying and persistence logic.  
		- Pros:  
			- Separates business logic from data access logic, adhering to the single responsibility principle.  
			- Provides a consistent API for accessing data, making it easier to switch between data sources or models.  
			- Facilitates testing by allowing mock repositories to replace actual data sources.  
		- Cons:  
			- May become overly complex if not carefully designed, particularly if it tries to support many use cases.  
			- Can introduce additional layers of abstraction, which might not always be necessary or beneficial.  

