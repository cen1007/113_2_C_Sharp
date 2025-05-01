namespace Password_Validation
{
    partial class Form1
    {
        /// <summary>
        /// 必需的設計器變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的資源。
        /// </summary>
        /// <param name="disposing">如果應釋放托管資源，則為 true。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計器生成的代碼

        /// <summary>
        /// 設計器支持所需的方法 - 請勿使用代碼編輯器修改此方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.promptLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.checkPasswordButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.Location = new System.Drawing.Point(21, 9);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(243, 93);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = "請輸入一個密碼，密碼必須包含：\n- 至少8個字元\n- 至少一個大寫字母\n- 至少一個小寫字母\n- 至少一個數字";
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.Location = new System.Drawing.Point(76, 108);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(132, 16);
            this.promptLabel.TabIndex = 1;
            this.promptLabel.Text = "請輸入一個密碼。";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(92, 135);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // checkPasswordButton
            // 
            this.checkPasswordButton.Location = new System.Drawing.Point(64, 169);
            this.checkPasswordButton.Name = "checkPasswordButton";
            this.checkPasswordButton.Size = new System.Drawing.Size(75, 36);
            this.checkPasswordButton.TabIndex = 3;
            this.checkPasswordButton.Text = "檢查密碼";
            this.checkPasswordButton.UseVisualStyleBackColor = true;
            this.checkPasswordButton.Click += new System.EventHandler(this.checkPasswordButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(145, 169);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 36);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 218);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.checkPasswordButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Name = "Form1";
            this.Text = "密碼驗證";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button checkPasswordButton;
        private System.Windows.Forms.Button exitButton;
    }
}

