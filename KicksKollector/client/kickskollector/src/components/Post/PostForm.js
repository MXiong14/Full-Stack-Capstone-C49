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
    <>
      <form className="postForm">
        <h2 className="postForm__title post_header">Add a new shoe</h2>
        <fieldset>
          <div className="form-group">
            <label htmlFor="name">Name</label>
            <input
              type="text"
              id="name"
              required
              autoFocus
              className="form-control"
              placeholder="Required"
              value={post.name}
              onChange={handleControlledInputChange}
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
              <option value="0">Select a Brand</option>
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
            <label htmlFor="Size">Size</label>
            <input
              type="text"
              id="size"
              required
              autoFocus
              className="form-control"
              placeholder=""
              value={post.size}
              onChange={handleControlledInputChange}
            />
          </div>
        </fieldset>
        <fieldset>
          <div className="form-group">
            <label htmlFor="styleCode">Style Code</label>
            <input
              type="text"
              id="styleCode"
              autoFocus
              className="form-control"
              placeholder=""
              value={post.styleCode}
              onChange={handleControlledInputChange}
            />
          </div>
        </fieldset>
        <fieldset>
          <div className="form-group">
            <label htmlFor="purchasePrice">Purchase Price</label>
            <textarea
              type="text"
              id="purchasePrice"
              required
              autoFocus
              className="form-control"
              placeholder=""
              value={post.purcahsePrice}
              onChange={handleControlledInputChange}
            />
          </div>
        </fieldset>
        <fieldset>
          <div className="form-group">
            <label htmlFor="soldPrice">Sold Price</label>
            <textarea
              type="text"
              id="soldPrice"
              required
              autoFocus
              className="form-control"
              placeholder=""
              value={post.soldPrice}
              onChange={handleControlledInputChange}
            />
          </div>
        </fieldset>
        <div className="buttons">
          <button
            className="pfbtns"
            onClick={(event) => {
              event.preventDefault();
              handleClickSavePost();
            }}
          >
            {postId ? "Edit Shoe" : "Save Shoe"}
          </button>{" "}
          {postId ? (
            <button className="pfbtns" onClick={() => history.goBack()}>
              Cancel
            </button>
          ) : (
            ""
          )}
        </div>
      </form>
    </>
  );
};
