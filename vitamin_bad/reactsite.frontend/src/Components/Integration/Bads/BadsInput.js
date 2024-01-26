import React, {Component} from 'react';
import axios from "axios";
import { Form, Select } from "antd";
import {FormBads} from "./FormBads";


const handleChange = (value: string) => {
    console.log(`selected ${value}`);
};
export default class BadsInput extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading:true,
            error: null,
            items:[]
        };
    }
    onFinish(values){
        axios.post('https://localhost:7001/Heabs', values)
            .then( response => {
                console.log(response.data)
                this.setState({ items: response.data,loading: false});
            })
            .catch(error => {
                console.error('Error:', error);
            });
    };
    static render(items){
        return (
            <div>
                <Form
                    name="basic"
                    labelCol={{ span: 10 }}
                    wrapperCol={{ span: 16 }}
                    style={{ maxWidth: 500 }}
                    initialValues={{ remember: true }}
                    autoComplete="off"
                    onFinish={this.handleSubmit}
                >
                    <Form.Item
                        label="Выберите из предложенных"
                        name="id_bads"
                    >
                        <Select
                            defaultValue="Выберете из списка"
                            style={{ width: 300 }}
                            onChange={handleChange}
                            options={items.map(item =>({
                                value: item.id,
                                label: item.name
                            }))}
                        />
                    </Form.Item>
                </Form>

            </div>
        );
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading... </em></p>
            : BadsInput.render(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                <FormBads response={this.onFinish.bind(this)}/>
                {contents}
            </div>
        );
    }
}
