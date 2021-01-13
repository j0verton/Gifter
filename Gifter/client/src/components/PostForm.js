import React from 'react'
import { FormGroup, Form, Label, Input } from 'reactstrap'
const PostForm = () => {
    return (
        <div className="container">
            <div className="row justify-content-center">
                <Form>
                    <FormGroup>
                        <Label for="title">Title
                        </Label>
                        <Input type="text" name="title" id="">
                        </Input>
                    </FormGroup>

                </Form>

            </div>
        </div>

    )

}