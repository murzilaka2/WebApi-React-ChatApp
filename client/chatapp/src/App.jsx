import 'bootstrap/dist/css/bootstrap.min.css'
import { Col, Row, Container } from 'react-bootstrap';
import WaitingRoom from './components/waitingroom'
import { useState } from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import ChatRoom from './components/ChatRoom';

function App() {

  const [conn, setConnection] = useState();
  const [messages, setMessages] = useState([]);

  const joinChatRoom = async (userName, chatRoom) => {
    try {

      //initiate a connection
      const conn = new HubConnectionBuilder()
        .withUrl("https://localhost:44376/chat")
        .configureLogging(LogLevel.Information)
        .build();

      //set up handler
      conn.on("ReceiveMessage", (userName, message) => {
        console.log("message:", message);
      });

      conn.on("ReceiveSpecificMessage", (userName, message) => {
        setMessages(messages => [...messages, { userName, message }]);
      });

      await conn.start();
      await conn.invoke("JoinSpecificChatRoom", { userName, chatRoom });

      setConnection(conn);

    } catch (e) {
      console.log(e);
    }
  };

  const sendMessage = async (message) => {
    try {
      await conn.invoke("SendMessage", message);
    } catch (e) {
      console.log(e);
    }
  }

  return (
    <div>
      <main>
        <Container>
          <Row class='px-5 my-5'>
            <Col sm='12'>
              <h1 className='font-weight-light'>Welcome to Chat App!</h1>
            </Col>
          </Row>
          {!conn
            ? <WaitingRoom joinChatRoom={joinChatRoom} />
            : <ChatRoom messages={messages} sendMessage={sendMessage} />
          }
        </Container>
      </main>
    </div>
  );
}

export default App;
