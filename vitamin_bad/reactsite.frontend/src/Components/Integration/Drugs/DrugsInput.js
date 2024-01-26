import React, {Component, useState} from 'react';
import {FormDrug} from "./FormDrug";
import axios from "axios";
import TextArea from "antd/es/input/TextArea";
import {Button, Form, Input, Select} from "antd";


const handleChange = (value: string) => {
    console.log(`selected ${value}`);
};
export default class DrugsInput extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading:true,
            error: null,
            items:[]
        };
    }
     onFinish(values){
        console.log(values)
        axios.post('https://localhost:7001/Drugs', {"name":values})
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
                        name="id_drug"
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
            : DrugsInput.render(this.state.items);
        console.log(this.state.items)
        return (
            <div>
                <FormDrug response={this.onFinish.bind(this)}/>
                {contents}
            </div>
        );
    }
}
