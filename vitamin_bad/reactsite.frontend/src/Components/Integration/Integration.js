import React from "react";
import {Button, Flex, Form, Input, Select} from "antd";
import axios from "axios";
import Tablebl from "./table";


class Integration extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            loading:0,
            items:[],
            id_drug:0,
            id_bad:0,
            interaction:[]
        };

        this.onFinish = this.onFinish.bind(this);
        this.onFinish2 = this.onFinish2.bind(this);
        this.handleChange=this.handleChange.bind(this);
        this.handleChange2=this.handleChange2.bind(this);
    }

    onFinish(values){
        console.log(values)
        axios.post('https://localhost:7001/Interaction', values)
            .then( response => {
                console.log(response.data)
                this.setState({
                    items: response.data,
                    loading:1});

            })
            .catch(error => {
                console.error('Error:', error);
            });
    };
    onFinish2(values){
        console.log(values)
        axios.post('https://localhost:7001/InteractionV2', values)
            .then( response => {
                console.log(response.data)
                this.setState({
                    loading:1,
                    items:this.state.items,
                    id_drug:this.state.id_drug,
                    id_bad:this.state.id_bad,
                    interaction:response.data});

            })
            .catch(error => {
                console.error('Error:', error);
            });
    };

    handleChange(value: string){
        console.log(`selected ${value}`);
    };
    handleChange2(value: string) {
        console.log(`selected ${value}`);
    };

static render(items){
    return(<Tablebl items={items}/>)
}
    render() {
    let comp= Integration.render(this.state.interaction)
        if(this.state.loading===0){
            return (
                <div>
                    <Form
                        name="basic"
                        labelCol={{span: 8}}
                        wrapperCol={{span: 16}}
                        style={{maxWidth: 1000, alignContent: "center"}}
                        initialValues={{remember: true}}
                        autoComplete="off"
                        onFinish={this.onFinish}
                    >
                        <Form.Item
                            label="Введите название лекарства"
                            name="name_drug"
                        >
                            <Input/>
                        </Form.Item>
                        <Form.Item
                            label="Введите название БАДА"
                            name="name_bad"
                        >
                            <Input/>
                        </Form.Item>
                        <Form.Item
                            wrapperCol={{offset: 8, span: 16}}
                        >
                            <Button type="primary" htmlType="submit">
                                Submit
                            </Button>
                        </Form.Item>
                    </Form>
                </div>
            )
        }else if(this.state.loading===1){
            return (<div>
                <Form
                    name="basic"
                    labelCol={{span: 10}}
                    wrapperCol={{span: 16}}
                    style={{maxWidth: 500}}
                    initialValues={{remember: true}}
                    autoComplete="off"
                    onFinish={this.onFinish2}
                >
                    <Form.Item
                        label="Выберите лекарство"
                        name="idDrug"
                    >
                        <Select
                            defaultValue="Выберете из списка"
                            style={{width: 300}}
                            onChange={this.handleChange}
                            options={this.state.items.drug.map(item => ({
                                value: item.id,
                                label: item.name
                            }))}
                        />
                    </Form.Item>
                    <Form.Item
                        label="Выберите Бад"
                        name="idHeab"
                    >
                        <Select
                            defaultValue="Выберете из списка"
                            style={{width: 300}}
                            onChange={this.handleChange2}
                            options={this.state.items.bad.map(item => ({
                                value: item.id,
                                label: item.name
                            }))}
                        />
                    </Form.Item>
                    <Form.Item
                        wrapperCol={{offset: 8, span: 16}}
                    >
                        <Button type="primary" htmlType="submit">
                            Submit
                        </Button>
                    </Form.Item>
                </Form>

                {comp}
            </div>)
        }else{
        }


    }
}

export {Integration};