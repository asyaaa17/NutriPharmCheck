import React from "react";
import { Button, Form, Input } from "antd";
class FormBads extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
        this.handleSubmit=props.response
    }

    handleSubmit = (event) => {
        event.preventDefault();
        // Handle form submission here
    }

    render() {
        return (
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 500 }}
                initialValues={{ remember: true }}
                autoComplete="off"
                onFinish={this.handleSubmit}
            >
                <Form.Item
                    label="Введите Бад"
                    name="name"
                    rules={[{ message: 'Введите название БАД' }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    wrapperCol={{ offset: 8, span: 16 }}
                >
                    <Button type="primary" htmlType="submit">
                        Submit
                    </Button>
                </Form.Item>
            </Form>
        )
    }
}

export { FormBads };