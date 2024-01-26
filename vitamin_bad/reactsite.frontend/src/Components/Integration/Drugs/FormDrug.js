import React from "react";
import { Button, Checkbox, Form, Input } from "antd";
import axios from "axios";
import Search from "antd/es/input/Search";
class FormDrug extends React.Component {
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
            <Search
                placeholder="Введите название лекарства"
                allowClear
                enterButton="Search"
                size="large"
                onSearch={this.handleSubmit}
            />
        )
    }
}

export { FormDrug };
