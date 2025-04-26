Event-driven Programming 
Assignment 

Emergency Response Simulation Game

This emergency response simulation game is written in c-sharp .
It simulates a simplified emergency response system where different emergency units are dispatched to handle incidents happening across a city randomly. 
The project demonstrates the use of Object-Oriented Programming (OOP) principles: abstraction, inheritance, polymorphism, and encapsulation.
Features
• Simulates incidents happening randomly at various locations.
• Different emergency units (Police, Firefighters, Ambulance, Rescue Team, Hazard Control) respond based on incident type.
• Manual selection of dispatch for the user
• Response speed scored dynamically 
It Works as the following 
The simulation runs for 5 round In each round A random incident type and location are generated.The user selects an appropriate emergency unit (if available).The selected unit responds, and points are awarded or deducted based on response effectiveness. Final score is displayed at the end.
Object-Oriented Concepts Used 
are abstraction as it is used to define common properties and methods for all units in abstract class "EmergencyUnit" .
And classes also inherent from the "EmergencyUnit"
Incase of polymorphism which means different forms , in this program it is Implemented in the way that each EmergencyUnit overrides the CanHandle and RespondToIncident methods in different way
.lastly Encapsulation is also Implemented in a way that properties and methods are grouped logically inside each class , keeping behaviour organized 

Class Structure Diagram 

EmergencyUnit (abstract)
├── Police
├── Firefighter
├── Ambulance
├── RescueTeam
└── HazardControl

Incident

EmergencyUnit: Base class with properties (Name, Speed) and abstract methods (CanHandle, RespondToIncident).

Subclasses override behavior based on incident type.

Incident class holds details about the incident (Type and Location).
 
Lessons Learned
Applying OOP concepts helps organize code better . To review and revise also understand the Concepts of OOP doing a project is very .
The use of each concepts in OOP practically ,
And understood them better.

Tried to implement the bonus Features as well

Challenges faced 

Was little hard to grasp the idea of the simulation game. 

The fact that the environment the IDE and a lot of things in it are a little unfamiliar to work with for this little more wider program , 
So trying to understand the work space and the IDE was a little challenging

Author
• Zereyakob Dereje
• ID = DBU1501600

