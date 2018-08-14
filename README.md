[![Build Status](https://travis-ci.org/micaol/bowling.svg?branch=master)](https://travis-ci.org/micaol/bowling)

# Getting started
1. Install Docker
Follow the instructions on the website: https://www.docker.com/get-started

2. Run the folowing command:
```
    docker run -ti -p 5001:80 micaol/bowling
```

# API specifications
1. Start a game

Name:               Start  
URL:                api/bowling/start   
                    (http://localhost:5001/api/bowling/start)  
Method:             POST  
Success Response:   OK: Game started  
Error Response:     501: "Internal server error"  
Sample Call:        curl -X POST -d{} http://localhost:5001/api/bowling/start   

2. Send the pins knocked

Name:               Play  
URL:                api/bowling/play/{nPinsKnocked}   
                    (http://localhost:5001/api/bowling/play/1)  
Parameter:          {nPinsKnocked} inteteger in [0:10] - REQUIRED  
Method:             POST  
Success Response:   OK: {nPinsKnocked}  
Error Responses:       
404: "The game did not start. Please start a new game (api/controller/start)."  
404: "The game is over. Please restart a new game (api/controller/start)."  
404: "The number of pins should be between 0 and X. \n You inputed: Y."  
501: "Internal server error"  
Sample Call:        curl -X POST -d{} http://localhost:5001/api/bowling/play/1  

3. Score of the Game  

Name:               Scores  
URL:                api/bowling/scores   
                    (http://localhost:5001/api/bowling/scores)  
Method:             GET  
Success Response:   {"frames": [-1,  -1,  -1,  -1,  -1, -1,  -1,  -1,  -1,  -1],"totalScore": -1 }  
Comment:            The score of the frame/game is -1 if it was not computed yet.   
Error Response:       
404: "The game did not start. Please start a new game (api/controller/start)."  
501: "Internal server error"  
Sample Call:        curl http://localhost:5001/api/bowling/scores  

4. Limitations  

Note the below limitations:   
- Single game: You can play only one game at a time.     
- Single player.  
- Speed (using a file to store the data)  


# Tests  

1. How manually run the tests?  
```
    cd Bowling.Tests
    dotnet restore
    dotnet test
```

2. The test are running automatically (continuous integration testing) with TravisCI at every commit.    
https://travis-ci.org/micaol/bowling

# Demo

![alt text](https://github.com/micaol/bowling/blob/master/demo.png)  
