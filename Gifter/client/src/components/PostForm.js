import React, { useContext } from 'react'
import { FormGroup, Form, Label, Input } from 'reactstrap'

const PostForm = () => {

    useContext(PostList)
    return (
        <div className="container">
            <div className="row justify-content-center">
                <Form>
                    <FormGroup>
                        <Label for="title">Title
                        </Label>
                        <Input type="text" name="title" id="">Post Title
                        </Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="imageUrl">Add a Gif Link
                        </Label>
                        <Input type="text" name="imageUrl" id="">https://media.giphy.com/media/XZrOvaUvmsCYL31HIe/giphy.gif
                        </Input>
                    </FormGroup>
                    <FormGroup>
                        <Label for="caption">Caption
                        </Label>
                        <Input type="text" name="caption" id="">Post Title
                        </Input>
                    </FormGroup>
                    <FormGroup>
                        <Input type="hidden" name="UserProfileId" id="">Post Title
                        </Input>
                    </FormGroup>
                    <FormGroup>
                        <Input type="hidden" name="dateCreated" id="">Post Title
                        </Input>
                    </FormGroup>

                </Form>

            </div>
        </div>
    )
}
export default PostForm;