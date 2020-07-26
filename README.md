# GreenVsRed

Hello, I'm Ivan and this is my solution for Green vs Red problem. 

I decided to separate the project into three parts: Input/Output module, GameEngine and Generation simulator.
I/O take care of gathering and writing data part.
The generation simulator calculates how many generations the targeted cell was green.
The Engine combinese all the parts together.

My decition was to separate the data reading and writing parts into separate modules, since usually a web app recieves data from multiple sources and also writes(or logs) the results on a server, or elsewhere. If i, or other programmer, would like to add different data reading/writing module in the future, it can be done fast and easy, using the IDataWriter/Reader abstraction and without touching the core algorithm. 

I was also debating whether or not to make GenerationsSimulator a static class, because in this current task i have simple matrix processing and no real need of object and trait inheritance -> i could just pass the data reading/writing abstractions and get the job done. However in the GenerationSimulator there is state tracking element (the 2d grid itself) and thought the code readability would be slightly better thatway.

