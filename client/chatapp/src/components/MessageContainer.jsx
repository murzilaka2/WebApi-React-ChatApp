import { Table } from "react-bootstrap";

const MessageContainer = ({ messages }) => {
    return (
        <Table striped bordered>
            <tbody>
                {messages.map((message, index) => (
                    <tr key={index}>
                        <td>{message.message} - {message.userName}</td>
                    </tr>
                ))}
            </tbody>
        </Table>
    );
};
export default MessageContainer;
