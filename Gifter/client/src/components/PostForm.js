import React, { useState } from "react";
import {
    Form,
    FormGroup,
    Card,
    CardBody,
    Label,
    Input,
    Button,
} from "reactstrap";
import { useHistory } from "react-router-dom";

const PostForm = () => {

    const [userProfileId, setUserProfileId] = useState("");
    const [imageUrl, setImageUrl] = useState("");
    const [title, setTitle] = useState("");
    const [caption, setCaption] = useState("");

    // Use this hook to allow us to programatically redirect users
    const history = useHistory();

    const addPost = (post) => {

        return fetch('api/post', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(post)
        })
            .then(res => res.json());
    }
    const submit = (e) => {
        const post = {
            imageUrl,
            title,
            caption,
            userProfileId: +userProfileId,
        };

        addPost(post).then((p) => {
            // Navigate the user back to the home route
            history.push("/");
        });
    };

    return (
        <div className="container">
            <div className="row justify-content-center">
                <Form className="postForm"
                    onSubmit={e => {
                        e.preventDefault()
                        // constructNewPost()
                    }}>
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
                    <Button type="submit"></Button>
                </Form>

            </div>
        </div>
    )
}
export default PostForm;