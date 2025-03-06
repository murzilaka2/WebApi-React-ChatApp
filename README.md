# Real-Time Chat Application (ASP.NET Core Web API + React + SignalR)

This is a simple real-time chat application where users can create or join rooms and communicate with each other instantly. The application uses **ASP.NET Core Web API** for the server-side, **React** for the front-end, and **SignalR** for real-time communication.

## Features

- **Create and Join Rooms**:  
  Users can create new chat rooms or join existing ones. Each room has a unique name and can be accessed via a link.
  
- **Real-Time Messaging**:  
  The application uses **SignalR** to enable real-time communication between users. New messages are instantly displayed to all members of the room.
  
- **Interactive UI with React**:  
  The client is built with **React**, allowing dynamic message updates without the need for page reloads. The user interface is simple and intuitive.
  
- **Instant Notifications**:  
  Users receive notifications about new messages without refreshing the page, providing a smooth and real-time chat experience.

## Technologies Used

- **ASP.NET Core Web API**:  
  The backend API responsible for handling requests related to room creation, joining rooms, and sending/receiving messages.

- **SignalR**:  
  Real-time communication library that facilitates instant message delivery between the client and server.
  
- **React**:  
  The frontend framework used to build the chat interface, which updates dynamically in response to new messages.

- **WebSockets**:  
  SignalR leverages WebSockets for bi-directional communication, allowing the server to push messages to the client without polling.
