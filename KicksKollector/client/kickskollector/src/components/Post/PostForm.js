import React, { useEffect, useState } from "react";
import { getAllBrands } from "../../modules/brandManager";
import { addPost, getAllPosts, getPostById } from "../../modules/postManager";
import { useHistory, useParams } from "react-router-dom";
import { editPost } from "../../modules/postManager";

export const PostForm = () => {
  const [post, setPost] = useState({});
  const [brand, setBrand] = useState([]);
  const history = useHistory();
  const { postId } = useParams();

  useEffect(() => {
    if (postId) {
      getPostById(postId).then((p) => {
        setPost(p);
      });
    }
    getAllBrands().then(setBrand);
  }, []);

  const handleControlledInputChange = (event) => {
    const newPost = { ...post };
    newPost[event.target.id] = event.target.value;
    setPost(newPost);
  };

  const handleClickSavePost = () => {
    if (post.name === undefined) {
      window.alert("Please complete the form");
    } else if (postId) {
      editPost({
        id: postId,
        name: post.name,
        size: post.size,
        styleCode: post.styleCode,
        quantity: post.quantity,
        purchasePrice: post.purchasePrice,
        soldPrice: post.soldPrice,
        brandId: post.brandId,
      }).then((p) => history.push("/MyInventory"));
    } else {
      const newPost = {
        name: post.name,
        size: post.size,
        styleCode: post.styleCode,
        quantity: post.quantity,
        purchasePrice: post.purchasePrice,
        soldPrice: post.soldPrice,
        brandId: post.brandId,
      };
      addPost(newPost).then((p) => history.push("/MyInventory"));
    }
  };

  return (
    <form className="Form">
      <h2 className="Form__title">{postId ? "Edit Post" : "Add A Shoe"}</h2>
      <fieldset>
        <div className="form-group">
          <label htmlFor="name">Name: </label>
          <input
            type="text"
            id="name"
            required
            autoFocus
            className="form-control"
            placeholder="Name"
            onChange={handleControlledInputChange}
            defaultValue={post.name}
          />
        </div>
      </fieldset>
      <fieldset>
        <div className="form-group">
          <label htmlFor="brand">Brand</label>
          <select
            value={post.brandId}
            name="brandId"
            id="brandId"
            className="form-control"
            onChange={handleControlledInputChange}
          >
            <option value="0">Select A Brand </option>
            {brand.map((b) => (
              <option key={b.id} value={b.id}>
                {b.name}
              </option>
            ))}
          </select>
        </div>
      </fieldset>
      <fieldset>
        <div className="form-group">
          <label htmlFor="Size">Size: </label>
          <input
            type="text"
            id="size"
            required
            autoFocus
            className="form-control"
            placeholder="Size"
            onChange={handleControlledInputChange}
            defaultValue={post.size}
          />
        </div>
      </fieldset>
      <fieldset>
        <div className="form-group">
          <label htmlFor="styleCode">Style Code: </label>
          <input
            type="text"
            id="styleCode"
            required
            autoFocus
            className="form-control"
            placeholder="Style Code"
            onChange={handleControlledInputChange}
            defaultValue={post.styleCode}
          />
        </div>
      </fieldset>
      <fieldset>
        <div className="form-group">
          <label htmlFor="quantity">Quantity: </label>
          <input
            type="text"
            id="quantity"
            required
            autoFocus
            className="form-control"
            placeholder="Quantity"
            onChange={handleControlledInputChange}
            defaultValue={post.quantity}
          />
        </div>
      </fieldset>
      <fieldset>
        <div className="form-group">
          <label htmlFor="purchasePrice">Purchase Price: </label>
          <input
            type="text"
            id="purchasePrice"
            required
            autoFocus
            className="form-control"
            placeholder="Purchase Price"
            onChange={handleControlledInputChange}
            defaultValue={post.purchasePrice}
          />
        </div>
      </fieldset>
      <fieldset>
        <div className="form-group">
          <label htmlFor="soldPrice">Sold Price: </label>
          <input
            type="text"
            id="soldPrice"
            required
            autoFocus
            className="form-control"
            placeholder="Sold Price"
            onChange={handleControlledInputChange}
            defaultValue={post.soldPrice}
          />
        </div>
      </fieldset>
      {/* <div>
        <div>
          <input
            type="file"
            onChange={(e) => setImage(e.target.files[0])}
          ></input>
          <button onClick={uploadImage}>Upload</button>
        </div>
        <div>
          <img src={url} />
        </div>
      </div> */}
      <button
        className="btn btn-primary"
        onClick={(event) => {
          event.preventDefault(); // Prevent browser from submitting the form and refreshing the page
          handleClickSavePost(post);
        }}
      >
        {postId ? "Save Shoe" : "Add A Shoe"}
      </button>
    </form>
  );
};
